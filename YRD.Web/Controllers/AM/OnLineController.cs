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
    /// 账户管理--在线升级
    /// </summary>
    public class OnLineController : BaseController
    {
        #region 在线升级
        [Authorization(1118)]
        public ActionResult OnlineUpgrade()
        {
            ViewOnlineUpGrade model = new ViewOnlineUpGrade();
            using (var db = new EFContext())
            {
                var selshop = db.selshop.FirstOrDefault(x => x.ID == ShopId);
                if (selshop != null)
                {
                    model.ShopName = selshop.ShopName;
                    model.StartTime = selshop.StartTime.ToString(FormatHelper.DateFormat);
                    if (selshop.VersionID == 1)
                    {
                        model.EndTime = "永久免费";
                    }
                    else
                    {
                        model.EndTime = selshop.EndTime.ToString(FormatHelper.DateFormat);
                    }

                    var versionList = db.sysversion.ToList();


                    var sysversion = versionList.FirstOrDefault(x => x.VersionID == selshop.VersionID);
                    if (sysversion != null)
                    {
                        model.VersionID = sysversion.VersionID;
                        model.VersionText = sysversion.Name;
                    }



                    var sysversion1 = versionList.FirstOrDefault(x => x.VersionID == 1);
                    if (sysversion1 != null)
                    {
                        model.Price1 = sysversion1.Price;
                        model.TableMaxCount1 = sysversion1.TableMaxCount;
                        model.PrintMaxCount1 = sysversion1.PrintMaxCount;
                        model.CashierMaxCount1 = sysversion1.CashierMaxCount;
                    }

                    var sysversion2 = versionList.FirstOrDefault(x => x.VersionID == 2);
                    if (sysversion2 != null)
                    {
                        model.Price2 = sysversion2.Price;
                        model.TableMaxCount2 = sysversion2.TableMaxCount;
                        model.PrintMaxCount2 = sysversion2.PrintMaxCount;
                        model.CashierMaxCount2 = sysversion2.CashierMaxCount;
                    }

                    var sysversion3 = versionList.FirstOrDefault(x => x.VersionID == 3);
                    if (sysversion3 != null)
                    {
                        model.Price3 = sysversion3.Price;
                        model.TableMaxCount3 = sysversion3.TableMaxCount;
                        model.PrintMaxCount3 = sysversion3.PrintMaxCount;
                        model.CashierMaxCount3 = sysversion3.CashierMaxCount;
                    }

                    var sysversion4 = versionList.FirstOrDefault(x => x.VersionID == 4);
                    if (sysversion4 != null)
                    {
                        model.Price4 = sysversion4.Price;
                        if (sysversion4.TableMaxCount >= 999)
                        {
                            model.TableMaxCount4 = "任意";
                        }
                        else
                        {
                            model.TableMaxCount4 = sysversion4.TableMaxCount.ToString();
                        }
                        if (sysversion4.PrintMaxCount >= 999)
                        {
                            model.PrintMaxCount4 = "任意";
                        }
                        else
                        {
                            model.PrintMaxCount4 = sysversion4.PrintMaxCount.ToString();
                        }

                        model.CashierMaxCount4 = sysversion4.CashierMaxCount;
                    }
                    var sysversion6 = versionList.FirstOrDefault(x => x.VersionID == 6);
                    if (sysversion6 != null)
                    {
                        model.Price6 = sysversion6.Price;
                        model.TableMaxCount6 = sysversion6.TableMaxCount;
                        model.PrintMaxCount6 = sysversion6.PrintMaxCount;
                        model.CashierMaxCount6 = sysversion6.PrintMaxCount;
                    }

                    var swhshopstockmodel = db.swhshopstock.FirstOrDefault(x => x.ShopID == ShopId);
                    if (swhshopstockmodel == null || swhshopstockmodel.IsBuyStock == 0)
                    {
                        model.WarehouseStartTime = string.Empty;
                        model.WarehouseEndTime = string.Empty;
                        model.IsWarehouse = 0;
                    }
                    else
                    {
                        model.WarehouseStartTime = swhshopstockmodel.StartTime.ToString(FormatHelper.DateFormat);
                        model.WarehouseEndTime = swhshopstockmodel.EndTime.ToString(FormatHelper.DateFormat);
                        model.IsWarehouse = 1;
                    }

                }
            }

            return View(model);
        }


        public ActionResult Do_2(FormCollection form)
        {
            ViewRecharge b = new ViewRecharge();
            var month = form.Get("month");
            var sendmonth = form.Get("sendmonth");
            var unitprice = form.Get("unitprice");
            var totalprice = form.Get("totalprice");
            int currentversion = 2;

            if (month.IsNull())
            {
                b.Code = 0;
                b.Message = "月份不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (unitprice.IsNull())
            {
                b.Code = 0;
                b.Message = "月份单价不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (totalprice.IsNull())
            {
                b.Code = 0;
                b.Message = "总价格不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (sendmonth.IsNull())
            {
                sendmonth = "0";
            }

            int _month = 0;
            try
            {
                _month = Convert.ToInt32(month);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            int _sendmonth = 0;
            try
            {
                _sendmonth = Convert.ToInt32(sendmonth);
            }
            catch (Exception exc)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            if (_sendmonth > 2 || _sendmonth < 0)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _unitprice = 0;
            try
            {
                _unitprice = Convert.ToDecimal(unitprice);
            }
            catch (Exception Exc)
            {

                b.Code = 0;
                b.Message = "单价格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _totalprice = 0;
            try
            {
                _totalprice = Convert.ToDecimal(totalprice);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "总价格格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            using (var db = new EFContext())
            {
                var currentsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (currentsysversion == null)
                {
                    b.Code = 0;
                    b.Message = "当前操作版本不正确！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }

                var selshop = db.selshop.FirstOrDefault(x => x.ID == ShopId);
                if (selshop == null)
                {
                    b.Code = 0;
                    b.Message = "商家账户不存在！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                int shopversion = selshop.VersionID;
                if (shopversion > currentversion)
                {
                    b.Code = 0;
                    b.Message = "无法购买低于账户当前版本的版本！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }

                var nextsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (nextsysversion.Price != _unitprice)
                {
                    b.Code = 0;
                    b.Message = "单价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                if (nextsysversion.Price * _month != _totalprice)
                {
                    b.Code = 0;
                    b.Message = "总价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                int totalmonth = _month + _sendmonth;
                bool isrenew = false;
                if (shopversion == currentversion)
                {
                    isrenew = true;
                }
                DateTime now = DateTime.Now;

                selshopversion model = new selshopversion()
                {
                    ID = WebTools.getGUID(),
                    ShopID = ShopId,
                    ManagerID = ManagerId,
                    CreateTime = now,
                    Money = _totalprice,
                    VersionID = currentversion,
                    Sort = 0,
                    CreateDate = now,
                    PayMode = 1,
                    MonthCount = totalmonth,
                    Status = 0
                };
                if (isrenew)
                {
                    now = selshop.EndTime;
                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}续费", currentsysversion.Name);
                    model.ReNew = 1;
                    db.selshopversion.Add(model);
                }
                else
                {

                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}开通", currentsysversion.Name);
                    model.ReNew = 0;
                    db.selshopversion.Add(model);

                }
                db.SaveChanges();
                b.Code = 1;
                b.Message = ConstantHelper.Success;
                b.Id = model.ID;
                b.BatchId = model.BatchId;
                b.Url = string.Format("/OnLine/OnLineUpgradeDetail?batchid={0}", b.BatchId);

            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Do_3(FormCollection form)
        {
            ViewRecharge b = new ViewRecharge();
            var month = form.Get("month");
            var sendmonth = form.Get("sendmonth");
            var unitprice = form.Get("unitprice");
            var totalprice = form.Get("totalprice");
            int currentversion = 3;

            if (month.IsNull())
            {
                b.Code = 0;
                b.Message = "月份不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (unitprice.IsNull())
            {
                b.Code = 0;
                b.Message = "月份单价不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (totalprice.IsNull())
            {
                b.Code = 0;
                b.Message = "总价格不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (sendmonth.IsNull())
            {
                sendmonth = "0";
            }

            int _month = 0;
            try
            {
                _month = Convert.ToInt32(month);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            int _sendmonth = 0;
            try
            {
                _sendmonth = Convert.ToInt32(sendmonth);
            }
            catch (Exception exc)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            if (_sendmonth > 2 || _sendmonth < 0)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _unitprice = 0;
            try
            {
                _unitprice = Convert.ToDecimal(unitprice);
            }
            catch (Exception Exc)
            {

                b.Code = 0;
                b.Message = "单价格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _totalprice = 0;
            try
            {
                _totalprice = Convert.ToDecimal(totalprice);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "总价格格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            using (var db = new EFContext())
            {
                var currentsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (currentsysversion == null)
                {
                    b.Code = 0;
                    b.Message = "当前操作版本不正确！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }

                var selshop = db.selshop.FirstOrDefault(x => x.ID == ShopId);
                if (selshop == null)
                {
                    b.Code = 0;
                    b.Message = "商家账户不存在！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                int shopversion = selshop.VersionID;
                if (shopversion > currentversion)
                {
                    b.Code = 0;
                    b.Message = "无法购买低于账户当前版本的版本！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }

                var nextsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (nextsysversion.Price != _unitprice)
                {
                    b.Code = 0;
                    b.Message = "单价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                if (nextsysversion.Price * _month != _totalprice)
                {
                    b.Code = 0;
                    b.Message = "总价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                int totalmonth = _month + _sendmonth;
                bool isrenew = false;
                if (shopversion == currentversion)
                {
                    isrenew = true;
                }
                DateTime now = DateTime.Now;

                selshopversion model = new selshopversion()
                {
                    ID = WebTools.getGUID(),
                    ShopID = ShopId,
                    ManagerID = ManagerId,
                    CreateTime = now,
                    Money = _totalprice,
                    VersionID = currentversion,
                    Sort = 0,
                    CreateDate = now,
                    PayMode = 1,
                    MonthCount = totalmonth,
                    Status = 0
                };
                if (isrenew)
                {
                    now = selshop.EndTime;
                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}续费", currentsysversion.Name);
                    model.ReNew = 1;
                    db.selshopversion.Add(model);
                }
                else
                {

                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}开通", currentsysversion.Name);
                    model.ReNew = 0;
                    db.selshopversion.Add(model);
                }
                db.SaveChanges();
                b.Code = 1;
                b.Message = ConstantHelper.Success;
                b.Id = model.ID;
                b.BatchId = model.BatchId;
                b.Url = string.Format("/OnLine/OnLineUpgradeDetail?batchid={0}", b.BatchId);

            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Do_4(FormCollection form)
        {
            ViewRecharge b = new ViewRecharge();
            var month = form.Get("month");
            var sendmonth = form.Get("sendmonth");
            var unitprice = form.Get("unitprice");
            var totalprice = form.Get("totalprice");
            int currentversion = 4;

            if (month.IsNull())
            {
                b.Code = 0;
                b.Message = "月份不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (unitprice.IsNull())
            {
                b.Code = 0;
                b.Message = "月份单价不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (totalprice.IsNull())
            {
                b.Code = 0;
                b.Message = "总价格不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (sendmonth.IsNull())
            {
                sendmonth = "0";
            }

            int _month = 0;
            try
            {
                _month = Convert.ToInt32(month);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            int _sendmonth = 0;
            try
            {
                _sendmonth = Convert.ToInt32(sendmonth);
            }
            catch (Exception exc)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            if (_sendmonth > 2 || _sendmonth < 0)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _unitprice = 0;
            try
            {
                _unitprice = Convert.ToDecimal(unitprice);
            }
            catch (Exception Exc)
            {

                b.Code = 0;
                b.Message = "单价格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _totalprice = 0;
            try
            {
                _totalprice = Convert.ToDecimal(totalprice);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "总价格格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            using (var db = new EFContext())
            {
                var currentsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (currentsysversion == null)
                {
                    b.Code = 0;
                    b.Message = "当前操作版本不正确！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }

                var selshop = db.selshop.FirstOrDefault(x => x.ID == ShopId);
                if (selshop == null)
                {
                    b.Code = 0;
                    b.Message = "商家账户不存在！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                int shopversion = selshop.VersionID;
                if (shopversion > currentversion)
                {
                    b.Code = 0;
                    b.Message = "无法购买低于账户当前版本的版本！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }

                var nextsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (nextsysversion.Price != _unitprice)
                {
                    b.Code = 0;
                    b.Message = "单价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                if (nextsysversion.Price * _month != _totalprice)
                {
                    b.Code = 0;
                    b.Message = "总价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                int totalmonth = _month + _sendmonth;
                bool isrenew = false;
                if (shopversion == currentversion)
                {
                    isrenew = true;
                }
                DateTime now = DateTime.Now;

                selshopversion model = new selshopversion()
                {
                    ID = WebTools.getGUID(),
                    ShopID = ShopId,
                    ManagerID = ManagerId,
                    CreateTime = now,
                    Money = _totalprice,
                    VersionID = currentversion,
                    Sort = 0,
                    CreateDate = now,
                    PayMode = 1,
                    MonthCount = totalmonth,
                    Status = 0
                };
                if (isrenew)
                {
                    now = selshop.EndTime;
                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}续费", currentsysversion.Name);
                    model.ReNew = 1;
                    db.selshopversion.Add(model);
                }
                else
                {

                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}开通", currentsysversion.Name);
                    model.ReNew = 0;
                    db.selshopversion.Add(model);
                }
                db.SaveChanges();
                b.Code = 1;
                b.Message = ConstantHelper.Success;
                b.Id = model.ID;
                b.BatchId = model.BatchId;
                b.Url = string.Format("/OnLine/OnLineUpgradeDetail?batchid={0}", b.BatchId);

            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Do_5(FormCollection form)
        //{
        //    ViewRecharge b = new ViewRecharge();
        //    var cbrd = form.Get("cbrd");

        //    if (cbrd.IsNull())
        //    {
        //        b.Code = 0;
        //        b.Message = "请阅读美味云分销规则";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }

        //    using (var db = new EFContext())
        //    {

        //        var selshop = db.selshop.FirstOrDefault(x => x.ID == ShopId);
        //        if (selshop == null)
        //        {
        //            b.Code = 0;
        //            b.Message = "当前用户无效";
        //            return Json(b, JsonRequestBehavior.AllowGet);
        //        }
        //        selshop.IsDistribution = 1;
        //        selshop.SetRebateTime = DateTime.Now.Date;
        //        b.Code = 1;
        //        b.Message = ConstantHelper.Success;
        //        db.SaveChanges();

        //        b.Url = string.Format("/sm/RebaterateSet");
        //    }
        //    return Json(b, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult Do_6(FormCollection form)
        //{
        //    ViewRecharge b = new ViewRecharge();
        //    var month = form.Get("month");
        //    var sendmonth = form.Get("sendmonth");
        //    var unitprice = form.Get("unitprice");
        //    var totalprice = form.Get("totalprice");
        //    var banktype = form.Get("banktype");

        //    if (month.IsNull())
        //    {
        //        b.Code = 0;
        //        b.Message = "月份不能为空";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }
        //    if (unitprice.IsNull())
        //    {
        //        b.Code = 0;
        //        b.Message = "月份单价不能为空";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }
        //    if (totalprice.IsNull())
        //    {
        //        b.Code = 0;
        //        b.Message = "总价格不能为空";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }
        //    if (sendmonth.IsNull())
        //    {
        //        sendmonth = "0";
        //    }

        //    int _month = 0;
        //    try
        //    {
        //        _month = Convert.ToInt32(month);
        //    }
        //    catch (Exception Exc)
        //    {
        //        b.Code = 0;
        //        b.Message = "月份格式不正确";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }

        //    int _sendmonth = 0;
        //    try
        //    {
        //        _sendmonth = Convert.ToInt32(sendmonth);
        //    }
        //    catch (Exception exc)
        //    {
        //        b.Code = 0;
        //        b.Message = "赠送月份格式不正确";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }

        //    if (_sendmonth > 3 || _sendmonth < 0)
        //    {
        //        b.Code = 0;
        //        b.Message = "赠送月份格式不正确";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }

        //    decimal _unitprice = 0;
        //    try
        //    {
        //        _unitprice = Convert.ToDecimal(unitprice);
        //    }
        //    catch (Exception Exc)
        //    {

        //        b.Code = 0;
        //        b.Message = "单价格式不正确";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }

        //    decimal _totalprice = 0;
        //    try
        //    {
        //        _totalprice = Convert.ToDecimal(totalprice);
        //    }
        //    catch (Exception Exc)
        //    {
        //        b.Code = 0;
        //        b.Message = "总价格格式不正确";
        //        return Json(b, JsonRequestBehavior.AllowGet);
        //    }

        //    using (var db = new EFContext())
        //    {
        //        int currentversion = 6;

        //        var selshop = db.selshop.FirstOrDefault(x => x.ID == ShopId);

        //        var nextsysversion = db.sysversion.FirstOrDefault(x => x.ID == currentversion.ToString());
        //        if (nextsysversion.Price != _unitprice)
        //        {
        //            b.Code = 0;
        //            b.Message = "单价数据不正确";
        //            return Json(b, JsonRequestBehavior.AllowGet);
        //        }
        //        if (nextsysversion.Price * _month != _totalprice)
        //        {
        //            b.Code = 0;
        //            b.Message = "总价数据不正确";
        //            return Json(b, JsonRequestBehavior.AllowGet);
        //        }
        //        bool isrenew = false;

        //        var swhshopstockmodel = db.swhshopstock.FirstOrDefault(x => x.ShopID == ShopId);
        //        if (swhshopstockmodel == null || swhshopstockmodel.IsBuyStock == 0)
        //        {
        //            isrenew = false;
        //        }
        //        else
        //        {
        //            isrenew = true;
        //        }

        //        DateTime now = DateTime.Now;
        //        selshopversion model = new selshopversion()
        //        {

        //            ID = WebTools.getGUID(),
        //            ShopID = ShopId,
        //            ManagerID = ManagerId,
        //            CreateTime = now,
        //            Money = _totalprice,
        //            BankType = int.Parse(banktype),
        //            IsDel = 0,
        //            VersionID = currentversion.ToString(),
        //            Sort = 0,
        //            CreateDate = now,
        //            MonthCount = _month + _sendmonth,
        //            Status = 0
        //        };

        //        if (isrenew)
        //        {
        //            now = swhshopstockmodel.EndTime;
        //            model.StartTime = now.Date;
        //            model.StartTime = now.AddMonths(_month + _sendmonth).Date;
        //            model.BatchId = BatchHelper.GetBatchId;
        //            model.Contents = string.Format("云库存续费 {0}到{1}", model.StartTime.ToString(FormatHelper.DateFormat), model.EndTime.ToString(FormatHelper.DateFormat));
        //            db.selshopversion.Add(model);
        //        }
        //        else
        //        {

        //            model.StartTime = now.AddDays(1).Date;
        //            model.EndTime = now.AddDays(1).AddMonths(_month + _sendmonth).Date;
        //            model.BatchId = BatchHelper.GetBatchId;
        //            model.Contents = string.Format("购买云库存 {0}到{1}", model.StartTime.ToString(FormatHelper.DateFormat), model.EndTime.ToString(FormatHelper.DateFormat));
        //            db.selshopversion.Add(model);
        //        }
        //        syspayhistory payhistory = new syspayhistory()
        //        {
        //            OrderMode = 3,
        //            OrderNumber = model.ID,
        //            CreateTime = now,
        //            Status = 0,
        //            BatchId = model.BatchId,
        //            Price = _totalprice
        //        };
        //        db.syspayhistory.Add(payhistory);
        //        db.SaveChanges();
        //        b.Code = 1;
        //        b.Message = ConstantHelper.Success;
        //        b.Id = model.ID;
        //        b.BatchId = model.BatchId;
        //        if (banktype == "1")
        //        {
        //            b.Url = string.Format("/Alipay/PayMoney?batchid={0}", b.BatchId);
        //        }
        //        else
        //        {
        //            b.Url = string.Format("/WeiXin/PayMoney?batchid={0}", b.BatchId);
        //        }
        //    }
        //    return Json(b, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Do_6(FormCollection form)
        {
            ViewRecharge b = new ViewRecharge();
            var month = form.Get("month");
            var sendmonth = form.Get("sendmonth");
            var unitprice = form.Get("unitprice");
            var totalprice = form.Get("totalprice");
            int currentversion = 6;

            if (month.IsNull())
            {
                b.Code = 0;
                b.Message = "月份不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (unitprice.IsNull())
            {
                b.Code = 0;
                b.Message = "月份单价不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (totalprice.IsNull())
            {
                b.Code = 0;
                b.Message = "总价格不能为空";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            if (sendmonth.IsNull())
            {
                sendmonth = "0";
            }

            int _month = 0;
            try
            {
                _month = Convert.ToInt32(month);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            int _sendmonth = 0;
            try
            {
                _sendmonth = Convert.ToInt32(sendmonth);
            }
            catch (Exception exc)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            if (_sendmonth > 2 || _sendmonth < 0)
            {
                b.Code = 0;
                b.Message = "赠送月份格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _unitprice = 0;
            try
            {
                _unitprice = Convert.ToDecimal(unitprice);
            }
            catch (Exception Exc)
            {

                b.Code = 0;
                b.Message = "单价格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            decimal _totalprice = 0;
            try
            {
                _totalprice = Convert.ToDecimal(totalprice);
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "总价格格式不正确";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            using (var db = new EFContext())
            {
                var currentsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (currentsysversion == null)
                {
                    b.Code = 0;
                    b.Message = "当前操作版本不正确！";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                bool isrenew = false;
                var selshopstock = db.swhshopstock.FirstOrDefault(x => x.ShopID == ShopId);
                if (selshopstock == null)
                {
                    isrenew = false;
                }
                else
                {
                    isrenew = true;
                }

                var nextsysversion = db.sysversion.FirstOrDefault(x => x.VersionID == currentversion);
                if (nextsysversion.Price != _unitprice)
                {
                    b.Code = 0;
                    b.Message = "单价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                if (nextsysversion.Price * _month != _totalprice)
                {
                    b.Code = 0;
                    b.Message = "总价数据不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                int totalmonth = _month + _sendmonth;

                DateTime now = DateTime.Now;

                selshopversion model = new selshopversion()
                {
                    ID = WebTools.getGUID(),
                    ShopID = ShopId,
                    ManagerID = ManagerId,
                    CreateTime = now,
                    Money = _totalprice,
                    VersionID = currentversion,
                    Sort = 0,
                    CreateDate = now,
                    PayMode = 1,
                    MonthCount = totalmonth,
                    Status = 0
                };
                if (isrenew)
                {
                    now = selshopstock.EndTime;
                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}续费", currentsysversion.Name);
                    model.ReNew = 1;
                    db.selshopversion.Add(model);
                }
                else
                {

                    model.StartTime = now.Date;
                    model.EndTime = now.AddMonths(totalmonth).Date;
                    model.BatchId = BatchHelper.GetBatchId;
                    model.Remark = string.Format("{0}开通", currentsysversion.Name);
                    model.ReNew = 0;
                    db.selshopversion.Add(model);
                }
                db.SaveChanges();
                b.Code = 1;
                b.Message = ConstantHelper.Success;
                b.Id = model.ID;
                b.BatchId = model.BatchId;
                b.Url = string.Format("/OnLine/OnLineUpgradeDetail?batchid={0}", b.BatchId);

            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OnLineUpgradeDetail(string batchid)
        {
            ViewOnlineUpGradePayment model = new ViewOnlineUpGradePayment();
            using (var db = new EFContext())
            {
                var b = db.selshopversion.FirstOrDefault(x => x.BatchId == batchid);
                if (b == null)
                {
                    return Redirect("/OnLine/OnLineUpgradeDetail");
                }
                else
                {
                    model.BatchId = b.BatchId;
                    model.StartTimeFormat = b.StartTime.ToString(FormatHelper.DateFormat);
                    model.EndTimeFormat = b.EndTime.ToString(FormatHelper.DateFormat);
                    model.TotalPrice = b.Money;
                    model.Remark = b.Remark;
                    model.VersionID = b.VersionID;
                }
            }

            return View(model);
        }



        public ActionResult OnLinePayment(ViewOnlineUpGradePayment model)
        {
            Base b = ShopPayPasswordHelper.CheckPassword(ShopId, model.PayPassword);
            if (b.Code == 0)
            {
                return Json(b, JsonRequestBehavior.AllowGet);
            }


            if (model.VersionID < 5)
            {
                return Json(OnLineUpGradePayment(model), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(OnLineStockPayment(model), JsonRequestBehavior.AllowGet);
            }
        }


        public ViewBase OnLineUpGradePayment(ViewOnlineUpGradePayment model)
        {
            ViewBase b = new ViewBase();


            using (var db = new EFContext())
            {
                decimal oldjinbi = 0;
                decimal newjinbi = 0;
                DateTime now = DateTime.Now;
                decimal jinbi = 0;

                var versionmodel = db.selshopversion.FirstOrDefault(x => x.VersionID == model.VersionID && x.BatchId == model.BatchId);
                if (versionmodel == null)
                {
                    b.Code = 0;
                    b.Message = "版本异常";
                    return b;
                }
                var currentversion = db.sysversion.FirstOrDefault(x => x.VersionID == model.VersionID);
                if (currentversion == null)
                {
                    b.Code = 0;
                    b.Message = "版本异常";
                    return b;
                }


                if (versionmodel.Status == 1)
                {
                    b.Code = 1;
                    b.Message = "支付成功！";
                    return b;
                }
                jinbi = versionmodel.Money;

                var selmanager = db.selmanager.FirstOrDefault(x => x.ShopID == ShopId && x.IsOwner == 1);
                if (selmanager == null)
                {
                    b.Code = 0;
                    b.Message = "店铺拥有者账户不存在";
                    return b;
                }

                var jinbiaccount = db.selshopjinbiaccount.FirstOrDefault(x => x.ShopID == ShopId);
                if (jinbiaccount == null)
                {
                    b.Code = 0;
                    b.Message = "金币账户不存在";
                    return b;
                }
                else
                {
                    oldjinbi = jinbiaccount.Jinbi;
                }
                selshop selshopmodel = db.selshop.FirstOrDefault(a => a.ID == ShopId);

                if (selshopmodel == null)
                {
                    b.Code = 0;
                    b.Message = "无效的帐户，请联系管理员！";
                    return b;
                }
                swhshopstock shopstock = db.swhshopstock.FirstOrDefault(a => a.ShopID == ShopId);
                //余额判断
                if (jinbiaccount.Jinbi < jinbi)
                {
                    b.Code = 0;
                    b.Message = string.Format("账号{0}余额{1}不足", ShopId, jinbiaccount.Jinbi);
                    return b;
                }


                //余额减少 

                newjinbi = oldjinbi - jinbi;
                jinbiaccount.Jinbi = newjinbi;
                jinbiaccount.OperatorDateTime = now;

                string ordernumber = WebTools.getGUID();
                string batchid = model.BatchId;

                selshopjinbidetail jinbidetail = new selshopjinbidetail()
                {
                    OrderNumber = ordernumber,
                    Type = 130,
                    ShopID = ShopId,
                    DT = now,
                    Sign = -1,
                    IsAuto = true,
                    Before = oldjinbi,
                    Data = jinbi,
                    After = newjinbi,
                    Remark = versionmodel.Remark,
                    BatchId = batchid
                };

                db.selshopjinbidetail.Add(jinbidetail);

                versionmodel.Status = 1;
                versionmodel.ConfirmDT = now;

                if (versionmodel.ReNew == 1)
                {
                    selshopmodel.EndTime = versionmodel.EndTime;
                }
                else
                {
                    selshopmodel.VersionID = versionmodel.VersionID;
                    selshopmodel.StartTime = versionmodel.StartTime;
                    selshopmodel.EndTime = versionmodel.EndTime;
                }
                bool isbuystock = false;

                #region 删除权限模块
                {
                    var selmanager_role = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == selmanager.ID);
                    if (selmanager_role != null)
                    {
                        db.selmanager_role.Remove(selmanager_role);

                        var role = db.selrole.FirstOrDefault(x => x.ID == selmanager_role.SelRoleID);
                        if (role != null)
                        {
                            db.selrole.Remove(role);

                            var role_pemit = db.selrole_pemit.Where(x => x.SelRoleID == role.ID);
                            if (role_pemit.Any())
                            {
                                db.selrole_pemit.RemoveRange(role_pemit);
                            }
                        }
                    }
                }
                #endregion

                #region 增加权限模块
                {
                    //增加权限
                    var role = new selrole()
                    {
                        ID = WebTools.getGUID(),
                        ShopID = selshopmodel.ID,
                        CreateManagerID = selmanager.ID,
                        CreateTime = now,
                        IsDefault = 1,
                        IsAvailable = 1,
                        Title = "云掌柜"
                    };
                    if (isbuystock == true)
                    {
                        role.Introduction = string.Format("云掌柜({0}+{1})", currentversion.Name, "云库存");
                    }
                    else
                    {
                        role.Introduction = string.Format("云掌柜({0})", currentversion.Name);
                    }
                    db.selrole.Add(role);
                    var selmanager_role = new selmanager_role() { ID = WebTools.getGUID(), SelManagerID = selmanager.ID, SelRoleID = role.ID };
                    db.selmanager_role.Add(selmanager_role);
                    var pemitstate = selshopmodel.VersionID.ToString();
                    if (isbuystock == true)
                    {
                        var selrole_pemit = db.selpemit.Where(x => (x.PemitState.Contains(pemitstate))||(x.PemitState.Contains("6"))).ToList().Select(x => new selrole_pemit() { ID = WebTools.getGUID(), SelPemitID = x.ID, SelRoleID = role.ID }).ToList();
                        db.selrole_pemit.AddRange(selrole_pemit);
                    }
                    else
                    {
                        var selrole_pemit = db.selpemit.Where(x => x.PemitState.Contains(pemitstate)).ToList().Select(x => new selrole_pemit() { ID = WebTools.getGUID(), SelPemitID = x.ID, SelRoleID = role.ID }).ToList();
                        db.selrole_pemit.AddRange(selrole_pemit);
                    }

                }

                #endregion

                db.SaveChanges();
                b.Code = 1;
                b.Message = "支付成功";
                b.Url = "/OnLine/OnLineUpgrade";

            }
            return b;
        }

        public ViewBase OnLineStockPayment(ViewOnlineUpGradePayment model)
        {
            ViewBase b = new ViewBase();


            using (var db = new EFContext())
            {
                decimal oldjinbi = 0;
                decimal newjinbi = 0;
                DateTime now = DateTime.Now;
                decimal jinbi = 0;

                var versionmodel = db.selshopversion.FirstOrDefault(x => x.VersionID == model.VersionID && x.BatchId == model.BatchId);
                if (versionmodel == null)
                {
                    b.Code = 0;
                    b.Message = "版本异常";
                    return b;
                }
                var currentversion = db.sysversion.FirstOrDefault(x => x.VersionID == model.VersionID);
                if (currentversion == null)
                {
                    b.Code = 0;
                    b.Message = "版本异常";
                    return b;
                }
                if (versionmodel.Status == 1)
                {
                    b.Code = 1;
                    b.Message = "支付成功！";
                    return b;
                }
                jinbi = versionmodel.Money;
                var selmanager = db.selmanager.FirstOrDefault(x => x.ShopID == ShopId && x.IsOwner == 1);
                if (selmanager == null)
                {
                    b.Code = 0;
                    b.Message = "店铺拥有者账户不存在";
                    return b;
                }
                var jinbiaccount = db.selshopjinbiaccount.FirstOrDefault(x => x.ShopID == ShopId);
                if (jinbiaccount == null)
                {
                    b.Code = 0;
                    b.Message = "金币账户不存在";
                    return b;
                }
                else
                {
                    oldjinbi = jinbiaccount.Jinbi;
                }
                selshop selshopmodel = db.selshop.FirstOrDefault(a => a.ID == ShopId);

                if (selshopmodel == null)
                {
                    b.Code = 0;
                    b.Message = "无效的帐户，请联系管理员！";
                    return b;
                }
                swhshopstock shopstock = db.swhshopstock.FirstOrDefault(a => a.ShopID == ShopId);

                //余额判断
                if (jinbiaccount.Jinbi < jinbi)
                {
                    b.Code = 0;
                    b.Message = string.Format("账号{0}余额{1}不足", ShopId, jinbiaccount.Jinbi);
                    return b;
                }


                //余额减少 

                newjinbi = oldjinbi - jinbi;
                jinbiaccount.Jinbi = newjinbi;
                jinbiaccount.OperatorDateTime = now;

                string ordernumber = WebTools.getGUID();
                string batchid = model.BatchId;

                selshopjinbidetail jinbidetail = new selshopjinbidetail()
                {
                    OrderNumber = ordernumber,
                    Type = 130,
                    ShopID = ShopId,
                    DT = now,
                    Sign = -1,
                    IsAuto = true,
                    Before = oldjinbi,
                    Data = jinbi,
                    After = newjinbi,
                    Remark = versionmodel.Remark,
                    BatchId = batchid
                };

                db.selshopjinbidetail.Add(jinbidetail);

                versionmodel.Status = 1;
                versionmodel.ConfirmDT = now;

                if (versionmodel.ReNew == 1)
                {
                    shopstock.EndTime = versionmodel.EndTime;
                    if (shopstock.EndTime > now)
                    {
                        shopstock.IsAvailable = true;
                    }
                    shopstock.IsBuyStock = 1;
                }
                else
                {
                    shopstock = new swhshopstock();
                    shopstock.ShopID = ShopId;
                    shopstock.StartTime = versionmodel.StartTime;
                    shopstock.EndTime = versionmodel.EndTime;
                    if (shopstock.EndTime > now)
                    {
                        shopstock.IsAvailable = true;
                    }
                    shopstock.IsBuyStock = 1;
                    db.swhshopstock.Add(shopstock);

                }

                #region 删除权限模块
                {
                    var selmanager_role = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == selmanager.ID);
                    if (selmanager_role != null)
                    {
                        db.selmanager_role.Remove(selmanager_role);

                        var role = db.selrole.FirstOrDefault(x => x.ID == selmanager_role.SelRoleID);
                        if (role != null)
                        {
                            db.selrole.Remove(role);

                            var role_pemit = db.selrole_pemit.Where(x => x.SelRoleID == role.ID);
                            if (role_pemit.Any())
                            {
                                db.selrole_pemit.RemoveRange(role_pemit);
                            }
                        }
                    }
                }
                #endregion

                #region 增加权限模块
                {
                    //增加权限
                    var role = new selrole()
                    {
                        ID = WebTools.getGUID(),
                        ShopID = selshopmodel.ID,
                        CreateManagerID = selmanager.ID,
                        CreateTime = now,
                        IsDefault = 1,
                        IsAvailable = 1,
                        Title = "云掌柜",
                        Introduction = string.Format("云掌柜({0}+{1})", currentversion.Name, "云库存")
                    };
                    db.selrole.Add(role);
                    var selmanager_role = new selmanager_role() { ID = WebTools.getGUID(), SelManagerID = selmanager.ID, SelRoleID = role.ID };
                    db.selmanager_role.Add(selmanager_role);
                    var pemitstate = selshopmodel.VersionID.ToString();
                    var selrole_pemit = db.selpemit.Where(x => (x.PemitState.Contains(pemitstate)) || (x.PemitState.Contains("6"))).ToList().Select(x => new selrole_pemit() { ID = WebTools.getGUID(), SelPemitID = x.ID, SelRoleID = role.ID }).ToList();
                    db.selrole_pemit.AddRange(selrole_pemit);
                }

                #endregion

                db.SaveChanges();
                b.Code = 1;
                b.Message = "支付成功";
                b.Url = "/OnLine/OnLineUpgrade";

            }
            return b;
        }

        #endregion
    }
}