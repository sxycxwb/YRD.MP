using Com.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;

namespace YRD.Web.Controllers
{
    public class AlipayController : Controller
    {
        /// <summary>
        /// 向支付宝账户提交充值记录
        /// </summary>
        /// <param name="id">充值编号</param>
        /// <returns></returns>
        public ContentResult PayMoney(string batchid)
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
                    switch (syspayhistory.OrderMode)
                    {
                        case 1:
                            #region 在线充值
                            {
                                var model = db.selshopjinbirecharge.FirstOrDefault(x => x.BatchId == batchid);
                                if (model == null)
                                {
                                    return Content("订单无效无法进行支付");
                                }

                                var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopID);
                                if (selshop == null)
                                {
                                    return Content("订单用户无效无法进行支付");
                                }

                                //数据库充值记录写入成功之后，调用支付接口开始充值

                                #region 支付参数
                                //商户订单号
                                string out_trade_no = model.BatchId;
                                //商户网站订单系统中唯一订单号，必填 在下面赋值

                                //订单名称
                                string subject = string.Format("美味云充值");
                                //必填

                                //付款金额
                                string total_fee = model.Data.ToString();
                                //必填

                                //订单描述
                                string body = string.Format("用户：{0} 于 {1} 向{2}充值{3}元，充值单号：{4}，商户订单号：{5}", selshop.ShopName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "美味云", total_fee, model.ID, model.BatchId);
                                //选填

                                //超时时间
                                string it_b_pay = "24h";
                                //选填

                                //钱包token
                                string extern_token = string.Empty;


                                //选填
                                #endregion

                                #region 把参数打包
                                SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                                sParaTemp.Add("service", Config.service);
                                sParaTemp.Add("partner", Config.partner);
                                sParaTemp.Add("seller_id", Config.seller_id);
                                sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
                                sParaTemp.Add("payment_type", Config.payment_type);
                                sParaTemp.Add("notify_url", Config.notify_url);
                                sParaTemp.Add("return_url", Config.return_url);
                                sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
                                sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
                                sParaTemp.Add("out_trade_no", out_trade_no);
                                sParaTemp.Add("subject", subject);
                                sParaTemp.Add("total_fee", total_fee);
                                sParaTemp.Add("body", body);
                                sParaTemp.Add("it_b_pay", it_b_pay);


                                #endregion
                                string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
                                Response.Write(sHtmlText);
                            }
                            #endregion
                            break;
                        case 2:
                            #region 短信充值

                            {
                                var model = db.selshopsmschange.FirstOrDefault(x => x.BatchId == batchid);
                                if (model == null)
                                {
                                    return Content("订单无效无法进行支付");
                                }

                                var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopID);
                                if (selshop == null)
                                {
                                    return Content("订单用户无效无法进行支付");
                                }

                                //数据库充值记录写入成功之后，调用支付接口开始充值

                                #region 支付参数
                                //商户订单号
                                string out_trade_no = model.BatchId;
                                //商户网站订单系统中唯一订单号，必填 在下面赋值

                                //订单名称
                                string subject = string.Format("美味云支付");
                                //必填

                                //付款金额
                                string total_fee = model.Money.ToString();
                                //必填

                                //订单描述
                                string body = string.Format("用户：{0} 于 {1} 向{2}支付{3}元，支付单号：{4}，商户订单号：{5}", selshop.ShopName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "美味云", total_fee, model.ID, model.BatchId);
                                //选填

                                //超时时间
                                string it_b_pay = "24h";
                                //选填

                                //钱包token
                                string extern_token = string.Empty;


                                //选填
                                #endregion

                                #region 把参数打包
                                SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                                sParaTemp.Add("service", Config.service);
                                sParaTemp.Add("partner", Config.partner);
                                sParaTemp.Add("seller_id", Config.seller_id);
                                sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
                                sParaTemp.Add("payment_type", Config.payment_type);
                                sParaTemp.Add("notify_url", Config.notify_url);
                                sParaTemp.Add("return_url", Config.return_url);
                                sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
                                sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
                                sParaTemp.Add("out_trade_no", out_trade_no);
                                sParaTemp.Add("subject", subject);
                                sParaTemp.Add("total_fee", total_fee);
                                sParaTemp.Add("body", body);
                                sParaTemp.Add("it_b_pay", it_b_pay);


                                #endregion
                                string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
                                Response.Write(sHtmlText);
                            }
                            #endregion 
                            break;
                        case 3:
                            #region 系统升级
                            {
                                var model = db.selshopversion.FirstOrDefault(x => x.BatchId == batchid);
                                if (model == null)
                                {
                                    return Content("订单无效无法进行支付");
                                }

                                var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopID);
                                if (selshop == null)
                                {
                                    return Content("订单用户无效无法进行支付");
                                }

                                //数据库充值记录写入成功之后，调用支付接口开始充值

                                #region 支付参数
                                //商户订单号
                                string out_trade_no = model.BatchId;
                                //商户网站订单系统中唯一订单号，必填 在下面赋值

                                //订单名称
                                string subject = string.Format("美味云支付");
                                //必填

                                //付款金额
                                string total_fee = model.Money.ToString();
                                //必填

                                //订单描述
                                string body = string.Format("用户：{0} 于 {1} 向{2}支付{3}元，支付单号：{4}，商户订单号：{5}", selshop.ShopName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "美味云", total_fee, model.ID, model.BatchId);
                                //选填

                                //超时时间
                                string it_b_pay = "24h";
                                //选填

                                //钱包token
                                string extern_token = string.Empty;


                                //选填
                                #endregion

                                #region 把参数打包
                                SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                                sParaTemp.Add("service", Config.service);
                                sParaTemp.Add("partner", Config.partner);
                                sParaTemp.Add("seller_id", Config.seller_id);
                                sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
                                sParaTemp.Add("payment_type", Config.payment_type);
                                sParaTemp.Add("notify_url", Config.notify_url);
                                sParaTemp.Add("return_url", Config.return_url);
                                sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
                                sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
                                sParaTemp.Add("out_trade_no", out_trade_no);
                                sParaTemp.Add("subject", subject);
                                sParaTemp.Add("total_fee", total_fee);
                                sParaTemp.Add("body", body);
                                sParaTemp.Add("it_b_pay", it_b_pay);


                                #endregion
                                string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
                                Response.Write(sHtmlText);
                            }
                            #endregion 
                            break;
                        default:
                            break;
                    }


                }
            }
            catch (Exception Exc)
            {
                return Content(Exc.ToString());
            }
            return Content(ConstantHelper.Success);
        }
        [HttpPost]
        public ActionResult notify_url()
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);
                if (verifyResult)//验证成功
                {
                    //商户订单号
                    string out_trade_no = Request.Form["out_trade_no"];
                    //支付宝缴易号(流水号)
                    string trade_no = Request.Form["trade_no"];
                    //缴易状态
                    string trade_status = Request.Form["trade_status"];

                    string passback_params = Request.Form["passback_params"];

                    string batchid = out_trade_no;
                    //DB.Log.Error("trade_no:" + trade_no.ToString());
                    //DB.Log.Error("trade_status:" + trade_status.ToString()); 

                    if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        var syspayhistory = DB.syspayhistory.Value.FirstOrDefault(x => x.BatchId == batchid);
                        if (syspayhistory == null)
                        {
                            return Content("");
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
                                return Content("success");
                            }
                            else
                            {
                                return Content("");
                            }

                        }
                        else if (syspayhistory.OrderMode == 2)
                        {
                            ///支付成功，进行充值确认
                            Base b = DB.selshopsmschange.Value.ConfirmShopVersionByBatchId(batchid);

                            if (b.Code == 1)
                            {
                                return Content("success");
                            }
                            else
                            {
                                return Content("");
                            }
                        }
                        else
                        {
                            ///支付成功，进行充值确认
                            //Base b = DB.selshopversion.Value.ConfirmShopVersionByBatchId(batchid);

                            //if (b.Code == 1)
                            //{
                            //    return Content("success");
                            //}
                            //else
                            //{
                            //    return Content("");
                            //}
                            return Content("");
                        }

                    }
                    else
                    {
                        return Content("");
                    }
                }
                else//验证失败
                {
                    return Content("fail");
                }
            }
            else
            {
                return Content("无通知参数");
            }
        }

        public ActionResult return_url()
        {

            try
            {
                SortedDictionary<string, string> sPara = GetRequestGet();

                if (sPara.Count > 0)//判断是否有带返回参数
                {
                    Notify aliNotify = new Notify();
                    bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);
                    var ilog = log4net.LogManager.GetLogger("LogToTXT");
                    ilog.Info("verifyResult:" + verifyResult.ToString());
                    if (verifyResult)//验证成功
                    {
                        //商户订单号
                        string out_trade_no = Request.QueryString["out_trade_no"];
                        //支付宝缴易号
                        string trade_no = Request.QueryString["trade_no"];
                        //缴易状态
                        string trade_status = Request.QueryString["trade_status"];

                        string passback_params = Request.Form["passback_params"];

                        string batchid = out_trade_no;
                        var type = batchid.Substring(36, 2);
                        ilog.Info("trade_no:" + trade_no.ToString());
                        ilog.Info("trade_status:" + trade_status.ToString()); ;
                        if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                        {
                            var syspayhistory = DB.syspayhistory.Value.FirstOrDefault(x => x.BatchId == batchid);
                            if (syspayhistory == null)
                            {
                                return Content("");
                            }

                            if (syspayhistory.OrderMode == 1)
                            {

                                ///支付成功，进行充值确认
                                Base b = DB.selshopjinbirecharge.Value.ConfirmAddRechargeByBatchId(batchid);

                                if (b.Code == 1)
                                {
                                    return Content("success");
                                }
                                else
                                {
                                    return Content("");
                                }

                            }
                            else if (syspayhistory.OrderMode == 2)
                            {
                                ///支付成功，进行充值确认
                                Base b = DB.selshopsmschange.Value.ConfirmShopVersionByBatchId(batchid);

                                if (b.Code == 1)
                                {
                                    return Content("success");
                                }
                                else
                                {
                                    return Content("");
                                }
                            }
                            else
                            {
                                ///支付成功，进行充值确认
                                //Base b = DB.selshopversion.Value.ConfirmShopVersionByBatchId(batchid);

                                //if (b.Code == 1)
                                //{
                                //    return Content("success");
                                //}
                                //else
                                //{
                                //    return Content("");
                                //}
                                return Content("");
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                //var ilog = log4net.LogManager.GetLogger("LogToTXT");
                //ilog.Info(string.Format("passback_params11:{0}", 1));
                //ilog.Info(string.Format("passback_params11:{0}", ee.ToString()));
            }
            return Redirect(string.Format("{0}/GoldBank/GoldBalance", ConfigHelper.GetHomeUrl));
        }

        #region 辅助方法
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load QueryString variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all QueryStrings into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }

        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load QueryString variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all QueryStrings into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
        }
        #endregion
    }
}
