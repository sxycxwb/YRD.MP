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
    /// 账户管理
    /// </summary>
    public class GoldBankController : BaseController
    {
        #region 账户余额
        /// <summary>
        /// 账户余额
        /// </summary>
        /// <returns></returns>
        [Authorization(1113)]
        public ActionResult GoldBalance()
        {
            var model = LoadAccountBalance();
            return View(model);
        }

        /// <summary>
        /// 加载帐户余额
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        private ViewShopJinbi LoadAccountBalance()
        {
            ViewShopJinbi model = new ViewShopJinbi();

            using (var db = new EFContext())
            {

                var jinbiaccount = db.selshopjinbiaccount.FirstOrDefault(x => x.ShopID == ShopId);
                if (jinbiaccount != null)
                {
                    model.Jinbi = jinbiaccount.Jinbi;
                }
            }
            return model;
        }
        #endregion

        #region 账户充值

        public ActionResult AddJinbiRecharge(string id)
        {
            ViewAddJinbiRecharge model = new ViewAddJinbiRecharge();
            return View(model);

        }
        public ActionResult SaveJinbiRecharge(ViewAddJinbiRecharge model)
        {
            ViewRecharge b = new ViewRecharge();

            if (model.Data < 0)
            {
                b.Code = 0;
                b.Message = "充值金额输入错误";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            ///向数据库写入充值记录

            var result = DB.selshopjinbirecharge.Value.AddRecharge(ShopId, ManagerId, model.Data, model.Mode, 0);
            if (result.Code == 1)
            {
                b.Code = result.Code;
                b.Message = result.Message;
                b.Id = result.Data.Id;
                b.BatchId = result.Data.BatchId;
                if (model.Mode == 2)
                {
                    b.Url = string.Format("/Alipay/PayMoney?batchid={0}", b.BatchId);
                }
                else
                {
                    b.Url = string.Format("/WeiXin/PayMoney?batchid={0}", b.BatchId);
                }

            }
            else
            {
                b.Code = result.Code;
                b.Message = result.Message;
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OnceAgainJinbiRecharge(string batchid)
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
                var query = db.selshopjinbirecharge.Where(x => x.ShopID == ShopId).AsQueryable();
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
                    ID = x.ID,
                    CreateTime = x.DT,
                    TypeText = "账户充值",
                    Money = x.Data,
                    PayType = x.Mode,
                    x.Contents,
                    PayTypeText = DB.selImp.Value.PayTypeList.FirstOrDefault(a => a.ID == (x.Mode))?.Name,
                    x.Status,
                    x.BatchId,
                    ConfirmDT = x.ConfirmDT.HasValue ? x.ConfirmDT.ToString(FormatHelper.DataTimeFormat) : ""
                }).ToList();
                return ToPageWithPaging(list, total);

            }
        }
         
        #endregion

        /// <summary>
        /// 金币明细
        /// </summary>
        /// <returns></returns>
        public ActionResult JinbiDetail()
        {
            //ViewBag.Table = "";
            //ViewBag.ddlshop = MySelect.ToSelectOrigin(MySelect.getShop(ShopId));
            return View();
        }

        public string getJinbiDetail(string keyword, string st, string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                ///查询数据
                var query = db.selshopjinbidetail.Where(x => x.ShopID == ShopId).AsQueryable();
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
                    Jinbi = x.Data * x.Sign,
                    x.Remark
                }).ToList();
                return ToPageWithPaging(list, total);

            }
        }
    }
}