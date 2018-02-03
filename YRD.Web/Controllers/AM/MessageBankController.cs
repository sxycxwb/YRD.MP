using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;
using YRD.Model.DomainModels;
using YRD.Model.EnumModels;
using YRD.Model.ViewModels; 

namespace YRD.Web.Controllers
{
    /// <summary>
    /// 账户管理--短信库
    /// </summary>
    public class MessageBankController : BaseController
    {
        #region 短信数量
        /// <summary>
        /// 短信数量
        /// </summary>
        /// <returns></returns>
        [Authorization(1117)]
        public ActionResult MessageBalance()
        {
            var model = LoadMessageBalance();
            return View(model);
        }

        /// <summary>
        /// 加载帐户余额
        /// </summary> 
        /// <returns></returns>
        private ViewShopSms LoadMessageBalance()
        {
            ViewShopSms model = new ViewShopSms();

            using (var db = new EFContext())
            {

                var smsaccount = db.selshopsmsaccount.FirstOrDefault(x => x.ShopID == ShopId);
                if (smsaccount != null)
                {
                    model.SmsCount = smsaccount.SmsCount;
                }
            }
            return model;
        }
        #endregion

        #region 账户充值

        public ActionResult AddMessageRecharge(string id)
        {
            ViewAddMessageRecharge model = new ViewAddMessageRecharge();
            using (var db = new EFContext())
            {
                model.ListSmsPackagePrice = db.syssmspackageprice.OrderBy(x => x.ID).ToList();
            }

            return View(model);

        }
        public ActionResult SaveMessageRecharge(ViewAddMessageRecharge model)
        {
            ViewRecharge b = new ViewRecharge();
            var totalprice = model.Price;
            var totalcount = model.SmsCount;

            if (totalprice < 0)
            {
                b.Code = 0;
                b.Message = "总价格格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (totalcount < 0)
            {
                b.Code = 0;
                b.Message = "总条数格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            var resultCheckPayPassword = ShopPayPasswordHelper.CheckPassword(ShopId, model.PayPassword);
            if (resultCheckPayPassword.Code == 0)
            {
                b.Code = 0;
                b.Message = "支付密码不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            try
            {
                using (var db = new EFContext())
                {

                    decimal oldjinbi = 0;
                    decimal newjinbi = 0;

                    int oldsmscount = 0;
                    int newsmscount = 0;
                    DateTime now = DateTime.Now;
                    decimal jinbi = totalprice;

                    var ts = totalcount.ToString();

                    var f = db.syssmspackageprice.FirstOrDefault(x => x.ID == ts && x.Price == totalprice);
                    if (f == null)
                    {
                        b.Code = 0;
                        b.Message = "短信条数格式不正确";
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }

                    var jinbiaccount = db.selshopjinbiaccount.FirstOrDefault(x => x.ShopID == ShopId);
                    if (jinbiaccount == null)
                    {
                        b.Code = 0;
                        b.Message = "金币账户不存在";
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        oldjinbi = jinbiaccount.Jinbi;
                    }

                    var smsaccount = db.selshopsmsaccount.FirstOrDefault(x => x.ShopID == ShopId);
                    if (smsaccount == null)
                    {
                        b.Code = 0;
                        b.Message = "短信账户不存在";
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        oldsmscount = smsaccount.SmsCount;
                    }


                    //余额判断
                    if (jinbiaccount.Jinbi < jinbi)
                    {
                        b.Code = 0;
                        b.Message = string.Format("账号{0}余额{1}不足", ShopId, jinbiaccount.Jinbi);
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }


                    //余额减少 

                    newjinbi = oldjinbi - jinbi;
                    jinbiaccount.Jinbi = newjinbi;
                    jinbiaccount.OperatorDateTime = now;


                    newsmscount = oldsmscount + totalcount;
                    smsaccount.SmsCount = newsmscount;
                    smsaccount.OperatorDateTime = now;


                    selshopsmsrecharge recharge = new selshopsmsrecharge()
                    {
                        ID = WebTools.getGUID(),
                        ShopID = ShopId,
                        SmsCount = totalcount,
                        Price = jinbi,
                        DT = now,
                        Status = 1,
                        IsAvailable = true,
                        ManagerID = ManagerId,
                        BatchId = WebTools.getGUID(),
                        ConfirmDT = now
                    };

                    db.selshopsmsrecharge.Add(recharge);

                    selshopjinbidetail jinbidetail = new selshopjinbidetail()
                    {
                        OrderNumber = recharge.ID,
                        Type = 120,
                        ShopID = ShopId,
                        DT = now,
                        Sign = -1,
                        IsAuto = true,
                        Before = oldjinbi,
                        Data = jinbi,
                        After = newjinbi,
                        Remark = "购买短信",
                        BatchId = recharge.BatchId
                    };
                    db.selshopjinbidetail.Add(jinbidetail);

                    selshopsmsdetail smsdetail = new selshopsmsdetail()
                    {
                        OrderNumber = recharge.ID,
                        Type = 120,
                        ShopID = ShopId,
                        DT = now,
                        Sign = 1,
                        IsAuto = true,
                        Before = oldsmscount,
                        Data = totalcount,
                        After = newsmscount,
                        Remark = "购买短信",
                        BatchId = recharge.BatchId

                    };

                    db.selshopsmsdetail.Add(smsdetail);
                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "购买短信成功";
                    b.Url = string.Format("/MessageBank/RechargeDetail");

                }

            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = ConstantHelper.Failure;
                b.Description = Exc.ToString();
            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OnceAgainMessageRecharge(string batchid)
        {
            if (batchid.IsNull())
            {
                return View("RechargeDetail");
            }

            var recharge = DB.selshopjinbirecharge.Value.FirstOrDefault(x => x.BatchId == batchid);

            if (recharge == null)
            {
                return View("RechargeDetail");
            }
            if (recharge.Mode == 2)
            {
                return Redirect(string.Format("/Alipay/PayMoney?batchid={0}", recharge.BatchId));
            }
            else
            {
                return Redirect(string.Format("/WeiXin/PayMoney?batchid={0}", recharge.BatchId));
            }

        }



        /// <summary>
        /// 充值明细
        /// </summary>
        /// <returns></returns>
        public ActionResult RechargeDetail()
        {
            //ViewBag.Table = "";
            //ViewBag.ddlshop = MySelect.ToSelectOrigin(MySelect.getShop(ShopId));
            return View();
        }
        #endregion

        #region 获取数据源
        public string getRechargeDetail(string keyword, string st, string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                ///查询数据
                var query = db.selshopsmsrecharge.Where(x => x.ShopID == ShopId).AsQueryable();
                if (keyword.IsNotNull())
                {
                    //query = query.Where(x => x.);
                }
                if (st.IsNotNull())
                {
                    DateTime _st = DateTime.Parse(st);
                    query = query.Where(x => x.DT >= _st);
                }
                if (et.IsNotNull())
                {
                    DateTime _et = DateTime.Parse(et);
                    query = query.Where(x => x.DT <= _et);
                }
                var total = query.EFLongCount();
                ///取当页数据列表
                var list = query.OrderByDescending(x => x.DT).Skip(start).Take(length).ToList().Select(x => new
                {
                    x.ID,
                    x.DT,

                    x.Price,
                    x.SmsCount
                }).ToList();
                return ToPageWithPaging(list, total);

            }
        }
         
        #endregion

        /// <summary>
        /// 充值明细
        /// </summary>
        /// <returns></returns>
        public ActionResult MessageDetail()
        {
            //ViewBag.Table = "";
            //ViewBag.ddlshop = MySelect.ToSelectOrigin(MySelect.getShop(ShopId));
            return View();
        }

        public string getMessageDetail(string keyword, string st, string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                ///查询数据
                var query = db.selshopsmsdetail.Where(x => x.ShopID == ShopId).AsQueryable();
                if (keyword.IsNotNull())
                {
                    //query = query.Where(x => x.);
                }
                if (st.IsNotNull())
                {
                    DateTime _st = DateTime.Parse(st);
                    query = query.Where(x => x.DT >= _st);
                }
                if (et.IsNotNull())
                {
                    DateTime _et = DateTime.Parse(et);
                    query = query.Where(x => x.DT <= _et);
                }
                var total = query.EFLongCount();
                ///取当页数据列表
                var list = query.OrderByDescending(x => x.DT).Skip(start).Take(length).ToList().Select(x => new
                {
                    CreateTime = x.DT,
                    SmsCount = x.Data * x.Sign,
                    x.Phone,
                    x.Type,
                    x.Remark
                }).ToList();

                var newlist = (from l in list
                               join t in db.syssmstype on l.Type equals t.ID into _t
                               from __t in _t.DefaultIfEmpty()
                               select new
                               {
                                   CreateTime = l.CreateTime,
                                   SmsCount = l.SmsCount,
                                   l.Phone,
                                   l.Type,
                                   TypeName = __t == null ? "" : __t.Title,
                                   l.Remark
                               }).ToList();

                return ToPageWithPaging(newlist, total);

            }
        }

    }
}