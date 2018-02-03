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
    /// 分销账户管理
    /// </summary>
    public class DistributionBankController : BaseController
    {
        #region 账户余额
        /// <summary>
        /// 账户余额
        /// </summary>
        /// <returns></returns>
        [Authorization(1119)]
        public ActionResult DistributionBalance()
        {
            var model = LoadDistributionAccountBalance();
            return View(model);
        }

        /// <summary>
        /// 加载帐户余额
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        private ViewDistributionJinbi LoadDistributionAccountBalance()
        {
            ViewDistributionJinbi model = new ViewDistributionJinbi();

            using (var db = new EFContext())
            {

                var jinbiaccount = db.selshopdistributionaccount.FirstOrDefault(x => x.ShopID == ShopId);
                if (jinbiaccount != null)
                {
                    model.Jinbi = jinbiaccount.Jinbi;
                    model.Deposit = jinbiaccount.Deposit;
                    model.Usable = jinbiaccount.Jinbi - model.Deposit;
                }

                var selshop = db.selshop.FirstOrDefault(x => x.ID == ShopId);
                if (selshop != null)
                {
                    var version = db.sysversion.FirstOrDefault(x => x.VersionID == selshop.VersionID);
                    if (version != null)
                    {
                        model.VersionID = version.VersionID;
                        model.VersionText = version.Name;
                    }
                }



            }
            return model;
        }
        #endregion

        #region 分销账户转入

        public ActionResult AddDistributionTakeIn()
        {
            ViewDistribution model = new ViewDistribution();
            return View(model);

        }
        public ActionResult SaveDistributionTakeIn(ViewDistribution model)
        {
            ViewRecharge b = new ViewRecharge();

            if (model.Jinbi < 0)
            {
                b.Code = 0;
                b.Message = "转入金额输入错误";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            ///向数据库写入充值记录
            try
            {
                using (var db = new EFContext())
                {

                    decimal oldjinbi = 0;
                    decimal newjinbi = 0;

                    decimal olddistributionjinbi = 0;
                    decimal newdistributionjinbi = 0;
                    DateTime now = DateTime.Now;
                    decimal jinbi = model.Jinbi;

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

                    var distributionaccount = db.selshopdistributionaccount.FirstOrDefault(x => x.ShopID == ShopId);
                    if (distributionaccount == null)
                    {
                        b.Code = 0;
                        b.Message = "分销账户不存在";
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        olddistributionjinbi = distributionaccount.Jinbi;
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

                    newdistributionjinbi = olddistributionjinbi + jinbi;
                    distributionaccount.Jinbi = newdistributionjinbi;
                    distributionaccount.OperatorDateTime = now;

                    string ordernumber = BatchHelper.GetBatchId;
                    string batchid = BatchHelper.GetBatchId;
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
                        Remark = "转入分销",
                        BatchId = batchid
                    };
                    db.selshopjinbidetail.Add(jinbidetail);

                    selshopdistributiondetail distributiondetail = new selshopdistributiondetail()
                    {
                        OrderNumber = ordernumber,
                        Type = 130,
                        ShopID = ShopId,
                        DT = now,
                        Sign = 1,
                        IsAuto = true,
                        Before = olddistributionjinbi,
                        Data = jinbi,
                        After = newdistributionjinbi,
                        Remark = "余额转入",
                        BatchId = batchid

                    };

                    db.selshopdistributiondetail.Add(distributiondetail);
                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "分销转入成功";
                    b.Url = string.Format("/DistributionBank/DistributionBalance");

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
        #endregion

        #region 分销账户转出

        public ActionResult AddDistributionTakeOut()
        {
            ViewDistribution model = new ViewDistribution();
            return View(model);

        }
        public ActionResult SaveDistributionTakeOut(ViewDistribution model)
        {
            ViewRecharge b = new ViewRecharge();

            if (model.Jinbi < 0)
            {
                b.Code = 0;
                b.Message = "转入金额输入错误";
                return Json(b, JsonRequestBehavior.AllowGet);
            }

            ///向数据库写入充值记录
            try
            {
                using (var db = new EFContext())
                {

                    decimal oldjinbi = 0;
                    decimal newjinbi = 0;

                    decimal olddistributionjinbi = 0;
                    decimal newdistributionjinbi = 0;
                    DateTime now = DateTime.Now;
                    decimal jinbi = model.Jinbi;

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

                    var distributionaccount = db.selshopdistributionaccount.FirstOrDefault(x => x.ShopID == ShopId);
                    if (distributionaccount == null)
                    {
                        b.Code = 0;
                        b.Message = "分销账户不存在";
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        olddistributionjinbi = distributionaccount.Jinbi;
                    }


                    //余额判断
                    if (distributionaccount.Jinbi < jinbi)
                    {
                        b.Code = 0;
                        b.Message = string.Format("账号{0}分销余额{1}不足", ShopId, jinbiaccount.Jinbi);
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }


                    //余额减少 

                    newdistributionjinbi = olddistributionjinbi - jinbi;
                    distributionaccount.Jinbi = newdistributionjinbi;
                    distributionaccount.OperatorDateTime = now;

                    newjinbi = oldjinbi + jinbi;
                    jinbiaccount.Jinbi = newjinbi;
                    jinbiaccount.OperatorDateTime = now;



                    string ordernumber = BatchHelper.GetBatchId;
                    string batchid = BatchHelper.GetBatchId;
                    selshopjinbidetail jinbidetail = new selshopjinbidetail()
                    {
                        OrderNumber = ordernumber,
                        Type = 131,
                        ShopID = ShopId,
                        DT = now,
                        Sign = 1,
                        IsAuto = true,
                        Before = oldjinbi,
                        Data = jinbi,
                        After = newjinbi,
                        Remark = "分销转入",
                        BatchId = batchid
                    };
                    db.selshopjinbidetail.Add(jinbidetail);

                    selshopdistributiondetail distributiondetail = new selshopdistributiondetail()
                    {
                        OrderNumber = ordernumber,
                        Type = 131,
                        ShopID = ShopId,
                        DT = now,
                        Sign = -1,
                        IsAuto = true,
                        Before = olddistributionjinbi,
                        Data = jinbi,
                        After = newdistributionjinbi,
                        Remark = "转入余额",
                        BatchId = batchid

                    };

                    db.selshopdistributiondetail.Add(distributiondetail);
                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "余额转入成功";
                    b.Url = string.Format("/DistributionBank/DistributionBalance");

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
                var query = db.selshopdistributiondetail.Where(x => x.ShopID == ShopId).AsQueryable();
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
                var list = query.OrderByDescending(x => x.DT).Skip(start).Take(length).ToList().Select(x => new ViewDistributionJinbiDetail
                {
                    CreateTime = x.DT.ToString(FormatHelper.DataTimeFormat),
                    Jinbi = x.Data * x.Sign,
                    Type = x.Type,
                    TypeName = "",
                    Remark = x.Remark
                }).ToList();

                foreach (var item in list)
                {
                    switch (item.Type)
                    {
                        case 1:
                            item.TypeName = "转入";
                            break;
                        case 2:
                            item.TypeName = "返俑";
                            break;
                        case 130:
                            item.TypeName = "余额转入";
                            break;
                        case 131:
                            item.TypeName = "转入余额";
                            break;
                        default:
                            break;
                    }
                }

                return ToPageWithPaging(list, total);

            }
        }

        public ActionResult DistributionOrder()
        {
            return View();
        }
        public ActionResult DistributionContract()
        {
            ViewDistributionContract model = new ViewDistributionContract();

            using (var db = new EFContext())
            {
                var shopdistribution = db.selshopdistribution.FirstOrDefault(x => x.ShopID == ShopId);
                if (shopdistribution != null)
                {
                    model.IsSignAgreement = shopdistribution.IsSignAgreement;
                    if (model.IsSignAgreement)
                    {
                        model.SignAgreementTimeFormat = shopdistribution.SignAgreementTime.Value.ToString(FormatHelper.DataTimeFormat);
                    }
                }

                var shop = db.selshop.FirstOrDefault(x => x.ID == ShopId);
                if (shop != null)
                {
                    model.LinkMan = shop.LinkMan;
                    model.Phone = shop.Phone;

                }

                model.ShopName = ShopName;
            }
            return View(model);
        }

        public ActionResult SaveDistributionContract(ViewDistributionContract model)
        {
            ViewBase b = new ViewBase();
            try
            {
                if (model.IsSignAgreement == false)
                {
                    b.Code = 0;
                    b.Message = ConstantHelper.Failure;
                    return Json(b, JsonRequestBehavior.AllowGet);
                }


                using (var db = new EFContext())
                {
                    var shopdistribution = db.selshopdistribution.FirstOrDefault(x => x.ShopID == ShopId);

                    if (shopdistribution == null)
                    {
                        shopdistribution = new selshopdistribution()
                        {
                            ShopID = ShopId,
                            IsSignAgreement = true,
                            SignAgreementTime = DateTime.Now,
                            IsOpen = false,
                            IsSetPercentage = false,
                            OperatorDateTime = DateTime.Now,
                            Percentage = 0,
                            SetPercentageTime = DateTime.Now
                        };
                        db.selshopdistribution.Add(shopdistribution);
                    }
                    else
                    {
                        shopdistribution.IsSignAgreement = true;
                        shopdistribution.SignAgreementTime = DateTime.Now;
                    }

                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "协议签署成功";
                    b.Url = "/DistributionBank/DistributionContract";
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
        public ActionResult DistributionPercentage()
        {
            ViewDistributionPercentage model = new ViewDistributionPercentage();

            using (var db = new EFContext())
            {
                var shopdistribution = db.selshopdistribution.FirstOrDefault(x => x.ShopID == ShopId);

                if (shopdistribution == null)
                {
                    shopdistribution = new selshopdistribution();
                }

                model.Percentage = Convert.ToInt16(shopdistribution.Percentage);
                model.IsSetPercentage = shopdistribution.IsSetPercentage;
                if (shopdistribution.IsSetPercentage)
                {

                    if (shopdistribution.SetPercentageTime.AddMonths(4) < DateTime.Now)
                    {
                        model.IsAllowSet = true;
                        model.SetPercentageTimeEndFormat = shopdistribution.SetPercentageTime.AddMonths(4).ToString(FormatHelper.DateFormat);
                       
                    }
                    else
                    {

                        model.IsAllowSet = false;
                        model.Days = (shopdistribution.SetPercentageTime.AddMonths(4) - DateTime.Now).Days;
                        model.SetPercentageTimeFormat = shopdistribution.SetPercentageTime.ToString(FormatHelper.DateFormat);


                    }
                }
                else
                {
                    model.SetPercentageTimeEndFormat = DateTime.Now.AddMonths(4).ToString(FormatHelper.DateFormat);

                    model.IsAllowSet = true;
                }
            }
            return View(model);
        }

        public ActionResult SaveDistributionPercentage(ViewDistributionPercentage model)
        {
            ViewBase b = new ViewBase();
            try
            {
                if (model.Percentage > 100 || model.Percentage < 8)
                {
                    b.Code = 0;
                    b.Message = "商家返利比例不正确";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }

                using (var db = new EFContext())
                {
                    var shopdistribution = db.selshopdistribution.FirstOrDefault(x => x.ShopID == ShopId);

                    if (shopdistribution == null)
                    {
                        shopdistribution = new selshopdistribution()
                        {
                            ShopID = ShopId,
                            IsSignAgreement = false,
                            IsOpen = false,
                            IsSetPercentage = true,
                            OperatorDateTime = DateTime.Now,
                            Percentage = model.Percentage,
                            SetPercentageTime = DateTime.Now.Date
                        };
                        db.selshopdistribution.Add(shopdistribution);
                    }
                    else
                    {
                        if (shopdistribution.IsSetPercentage)
                        {
                            model.SetPercentageTimeFormat = shopdistribution.SetPercentageTime.AddMonths(4).ToString(FormatHelper.DateFormat);
                            if (shopdistribution.SetPercentageTime.AddMonths(4) > DateTime.Now)
                            {
                                b.Message = string.Format("返佣比例提交后一个季度才可修改一次,上次提交时间为:{0}", shopdistribution.SetPercentageTime.ToString(FormatHelper.DateFormat));
                                return Json(b, JsonRequestBehavior.AllowGet);
                            }
                        }
                        shopdistribution.Percentage = model.Percentage;
                        shopdistribution.SetPercentageTime = DateTime.Now.Date;
                        shopdistribution.IsSetPercentage = true;
                    }

                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = ConstantHelper.Success;
                    b.Url = "/DistributionBank/DistributionPercentage";
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

        public ActionResult DistributionOpen()
        {
            ViewDistributionOpen model = new ViewDistributionOpen();

            using (var db = new EFContext())
            {
                var shopdistribution = db.selshopdistribution.FirstOrDefault(x => x.ShopID == ShopId);

                //if (shopdistribution == null || shopdistribution.IsSignAgreement == false)
                //{
                //    return RedirectToAction("DistributionContract");
                //}

                model.IsOpen = shopdistribution.IsOpen;
                model.IsSignAgreement = shopdistribution.IsSignAgreement;

            }
            return View(model);
        }

        public ActionResult SaveDistributionOpen(ViewDistributionOpen model)
        {
            ViewBase b = new ViewBase();
            try
            {
                using (var db = new EFContext())
                {
                    var shopdistribution = db.selshopdistribution.FirstOrDefault(x => x.ShopID == ShopId);

                    if (shopdistribution == null || shopdistribution.IsSignAgreement == false)
                    {
                        b.Code = 1;
                        b.Message = "签署合同后才能开启";
                        b.Url = "/DistributionBank/DistributionContract";
                        return Json(b, JsonRequestBehavior.AllowGet);
                    }
                    selshopdistributionopendetail log = new selshopdistributionopendetail()
                    {
                        ID = WebTools.getGUID(),
                        ShopID = ShopId,
                        CreateTime = DateTime.Now,
                        IsAuto = false,
                        IsOpen = model.IsOpen,
                        ManagerId = ManagerId,
                        Remark = string.Empty
                    };
                    db.selshopdistributionopendetail.Add(log);
                    shopdistribution.IsOpen = model.IsOpen;
                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = ConstantHelper.Success;
                    b.Url = "/DistributionBank/DistributionOpen";
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
    }
}