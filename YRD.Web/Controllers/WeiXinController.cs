using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ThoughtWorks.QRCode.Codec;
using WxPayAPI;


namespace WXPay.Controllers
{
    public class WeiXinController : Controller
    {
        #region 支付
        public ActionResult PayMoney(string batchid)
        {
            try
            {
                using (var db = new EFContext())
                {
                    var syspayhistory = db.syspayhistory.FirstOrDefault(x => x.BatchId == batchid);
                    if (syspayhistory == null)
                    {
                        return Content("订单无效无法进行支付");

                    }
                    ViewBag.price = syspayhistory.Price;
                    ViewBag.batchid = batchid;
                }
            }
            catch (Exception Exc)
            {
                return Content("订单异常无法进行支付");
            }

            return View();
        }
        #endregion

        #region 生成订单支付码      

        public FileResult GetQRCode(string batchid)
        {
            string strQRCodeStr = GetPayUrl(batchid);
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

            var img = qrCodeEncoder.Encode(strQRCodeStr);

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return File(ms.ToArray(), @"image/jpeg");
        }

        public string GetPayUrl(string batchid)
        {
            try
            {
                using (var db = new EFContext())
                {
                    var syspayhistory = db.syspayhistory.FirstOrDefault(x => x.BatchId == batchid);
                    if (syspayhistory == null)
                    {
                        return "订单无效无法进行支付";
                    }

                    if (syspayhistory.OrderMode == 1)
                    {
                        #region 在线充值
                        {
                            var model = db.selshopjinbirecharge.FirstOrDefault(x => x.BatchId == batchid);
                            if (model == null)
                            {
                                return "订单无效无法进行支付";
                            }

                            var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopID);
                            if (selshop == null)
                            {
                                return "订单用户无效无法进行支付";
                            }

                            //数据库充值记录写入成功之后，调用支付接口开始充值

                            int total_fee = (int)(model.Data * 100);

                            WxPayData wxpaydata = new WxPayData();
                            //订单名称
                            string subject = string.Format("美味云充值");
                            //订单描述
                            string body = string.Format("用户：{0} 于 {1} 向{2}充值{3}元，充值单号：{4}，商户订单号：{5}", selshop.ShopName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "美味云", total_fee, model.ID, model.BatchId);
                            wxpaydata.SetValue("body", subject);//商品描述
                            wxpaydata.SetValue("attach", batchid);//附加数据
                            wxpaydata.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());//随机字符串 

                            ///金额
                            wxpaydata.SetValue("total_fee", total_fee);//总金额 以分为整数单位 

                            wxpaydata.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
                            wxpaydata.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
                            wxpaydata.SetValue("goods_tag", body);//商品标记  商品的备忘,可以自定义
                            wxpaydata.SetValue("trade_type", "NATIVE");//交易类型
                            wxpaydata.SetValue("product_id", batchid);//商品ID

                            WxPayData newresult = WxPayApi.UnifiedOrder(wxpaydata);//调用统一下单接口

                            string codeurl = newresult.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接

                            return codeurl;

                        }
                        #endregion
                    }
                    else if (syspayhistory.OrderMode == 2)
                    {
                        #region 短信充值

                        {

                            var model = db.selshopsmschange.FirstOrDefault(x => x.BatchId == batchid);
                            if (model == null)
                            {
                                return "订单无效无法进行支付";
                            }

                            var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopID);
                            if (selshop == null)
                            {
                                return "订单用户无效无法进行支付";
                            }

                            //数据库充值记录写入成功之后，调用支付接口开始充值
                            int total_fee = (int)(model.Money * 100);

                            WxPayData wxpaydata = new WxPayData();
                            //订单名称
                            string subject = string.Format("美味云支付");
                            //订单描述
                            //订单描述
                            string body = string.Format("用户：{0} 于 {1} 向{2}支付{3}元，支付单号：{4}，商户订单号：{5}", selshop.ShopName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "美味云", total_fee, model.ID, model.BatchId);
                            wxpaydata.SetValue("body", subject);//商品描述
                            wxpaydata.SetValue("attach", batchid);//附加数据
                            wxpaydata.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());//随机字符串



                            ///金额
                            wxpaydata.SetValue("total_fee", total_fee);//总金额 以分为整数单位


                            wxpaydata.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
                            wxpaydata.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
                            wxpaydata.SetValue("goods_tag", body);//商品标记
                            wxpaydata.SetValue("trade_type", "NATIVE");//交易类型
                            wxpaydata.SetValue("product_id", batchid);//商品ID

                            WxPayData newresult = WxPayApi.UnifiedOrder(wxpaydata);//调用统一下单接口
                            string codeurl = newresult.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接

                            return codeurl;



                        }
                        #endregion
                    }
                    else if (syspayhistory.OrderMode == 3)
                    {
                        #region 系统升级
                        {

                            var model = db.selshopversion.FirstOrDefault(x => x.BatchId == batchid);
                            if (model == null)
                            {
                                return "订单无效无法进行支付";
                            }

                            var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopID);
                            if (selshop == null)
                            {
                                return "订单用户无效无法进行支付";
                            }

                            //数据库充值记录写入成功之后，调用支付接口开始充值
                            var total_fee = (int)(model.Money * 100);
                            WxPayData wxpaydata = new WxPayData();
                            //订单名称
                            string subject = string.Format("美味云支付");
                            //订单描述
                            //订单描述
                            string body = string.Format("用户：{0} 于 {1} 向{2}支付{3}元，支付单号：{4}，商户订单号：{5}", selshop.ShopName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "美味云", total_fee, model.ID, model.BatchId);
                            wxpaydata.SetValue("body", subject);//商品描述
                            wxpaydata.SetValue("attach", batchid);//附加数据
                            wxpaydata.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());//随机字符串


                            ///金额
                            wxpaydata.SetValue("total_fee", total_fee);//总金额 以分为整数单位


                            wxpaydata.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
                            wxpaydata.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
                            wxpaydata.SetValue("goods_tag", body);//商品标记
                            wxpaydata.SetValue("trade_type", "NATIVE");//交易类型
                            wxpaydata.SetValue("product_id", batchid);//商品ID

                            WxPayData newresult = WxPayApi.UnifiedOrder(wxpaydata);//调用统一下单接口
                            string codeurl = newresult.GetValue("code_url").ToString();//获得统一下单接口返回的二维码链接

                            return codeurl;
                        }
                        #endregion 
                    }
                    else
                    {
                        return "订单无效无法进行支付";
                    }
                }
            }
            catch (Exception Exc)
            {
                return "订单异常无法进行支付";
            }
        }
        #endregion

        // GET: NativeNotify 微信支付通知 
        public ActionResult notify_url()
        {
            string strData = ProcessNotify();
            //Response.Write(strData);
            return View();
        }


        /// <summary>
        /// 页面Ajax请求跳转
        /// </summary>
        /// <returns></returns>
        public ActionResult return_url(string batchid, string price)
        {
            ViewBag.batchid = batchid;
            ViewBag.price = price;
            return View();
        }

        public ActionResult Refresh(string batchid, string price)
        {
            ViewBase b = new ViewBase();


            using (var db = new EFContext())
            {
                var syspayhistory = db.syspayhistory.FirstOrDefault(x => x.BatchId == batchid);
                if (syspayhistory != null && syspayhistory.Status == 1)
                {
                    b.Url = string.Format("{0}/WeiXin/return_url?batchid={1}&price={2}", ConfigHelper.GetHomeUrl, batchid, price);
                    b.Code = 1;
                    b.Message = ConstantHelper.Success;
                }
            }

            return Json(b);
        }

        public string ProcessNotify()
        {
            WritePayTextLog("kaishi");
            WxPayData notifyData = GetNotifyData();
            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                WritePayTextLog("支付二结果中微信订单号不存在");
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付二结果中微信订单号不存在");
                return res.ToXml();
            }
            string transaction_id = notifyData.GetValue("transaction_id").ToString();
            WritePayTextLog("支付二结果中微信订单号:" + transaction_id);
            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                WritePayTextLog("二订单查询失败:" + transaction_id);
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "二订单查询失败");
                return res.ToXml();
            }
            //查询订单成功
            else
            {
                WritePayTextLog("二订单查询成功:" + transaction_id);
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");

                string strXml = res.ToXml();

                WritePayTextLog("二订单信息:" + strXml);

                return res.ToXml();//如果我们走到这一步了，那就代表，用户已经支付成功了，所以，该干嘛干嘛了。
            }
        }
        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public WxPayData GetNotifyData()
        {
            //接收从微信后台POST过来的数据
            System.IO.Stream s = Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();
            Log.Info(this.GetType().ToString(), "Receive data from WeChat : " + builder.ToString());
            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                Log.Error(this.GetType().ToString(), "Sign check error : " + res.ToXml());
                return res;
            }

            return data;
        }
        //查询订单
        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);

            WritePayTextLog("二订单查询成功详情:" + res.ToXml());

            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                var batchid = res.GetValue("attach").ToString();
                //回调成功处理
                var syspayhistory = DB.syspayhistory.Value.FirstOrDefault(x => x.BatchId == batchid);
                if (syspayhistory == null)
                {
                    return false;
                }
                if (syspayhistory.Status == 0)
                {
                    syspayhistory.Status = 1;
                    DB.syspayhistory.Value.Update(syspayhistory);
                }
                if (syspayhistory.OrderMode == 1)
                {

                    ///支付成功，进行充值确认
                    Base b = DB.selshopjinbirecharge.Value.ConfirmAddRechargeByBatchId(batchid);

                    if (b.Code == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (syspayhistory.OrderMode == 2)
                {
                    ///支付成功，进行充值确认
                    Base b = DB.selshopsmschange.Value.ConfirmShopVersionByBatchId(batchid);

                    if (b.Code == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    ///支付成功，进行充值确认
                    //Base b = DB.selshopversion.Value.ConfirmShopVersionByBatchId(batchid);

                    //if (b.Code == 1)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
























        /// <summary>
        ///  写入日志到文本文件 
        /// </summary>
        /// <param name="ex">catch到的错误</param>
        public void WritePayTextLog(string msg)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"SysLog\PayLog\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var time = DateTime.Now;
            string fileFullPath = path + time.ToString("yyyy-MM-dd") + "Pay.txt";
            StringBuilder str = new StringBuilder();
            str.Append("Time:    " + time + "\r\n");
            str.Append("Message: " + msg + "\r\n");
            str.Append("-----------------------------------------------------------\r\n\r\n");
            StreamWriter sw;

            if (!System.IO.File.Exists(fileFullPath))
            {
                sw = System.IO.File.CreateText(fileFullPath);
            }
            else
            {
                sw = System.IO.File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }








    }
}