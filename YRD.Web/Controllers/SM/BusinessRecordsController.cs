using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;
using YRD.Model.ViewModels;

namespace YRD.Web.Controllers
{
    public class BusinessRecordsController : BaseController
    {

        public ActionResult OmOperationRecord()
        {
            return View();
        }

        public string getOmOperationRecord(string st, string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                var sumTotal = (decimal?)0;//营收总金额
                var countTotal = (int?)0;//营收总单数
                //不包含会员卡
                Hashtable hashTable_sum = new Hashtable();
                Hashtable hashTable_count = new Hashtable();
                var paymentTypeList1 = db.cuspaymenttype.Where(p => !new int[] { 151, 152, 153, 154, 155 }.Contains(p.ID)).Select(p => new { p.ID, p.Title }).ToList();

                var querycuspayment = db.cuspayment.Where(x => x.ShopID == ShopId).AsQueryable();
                var querycuspaymentassociatedorders = db.cuspaymentassociatedorders.Where(x => x.ShopId == ShopId).AsQueryable();
                var querycuspaymentdetail = db.cuspaymentdetail.Where(x => x.ID != null).AsQueryable();
                var querycusreserve = db.cusreserve.Where(x => x.ShopID == ShopId).AsQueryable();
                var querycusrepayment = db.cusrepayment.AsQueryable();

                DateTime _st = DateTime.Now.Date.AddDays(-1);
                if (st.IsNotNull())
                {
                    _st = DateTime.Parse(st);
                    querycuspaymentdetail = querycuspaymentdetail.Where(x => x.CreateTime >= _st);
                    querycusreserve = querycusreserve.Where(x => x.CreateTime >= _st);
                    querycusrepayment = querycusrepayment.Where(x => x.CreateTime >= _st);
                }
                DateTime _et = DateTime.Now;
                if (et.IsNotNull())
                {
                    _et = DateTime.Parse(et);
                    querycuspaymentdetail = querycuspaymentdetail.Where(x => x.CreateTime <= _et);
                    querycusreserve = querycusreserve.Where(x => x.CreateTime <= _et);
                    querycusrepayment = querycusrepayment.Where(x => x.CreateTime <= _et);
                }

                var querySingle = from pd in querycuspaymentdetail
                                  join pao in querycuspaymentassociatedorders on pd.PaymentID equals pao.PaymentID
                                  select new
                                  {
                                      PaymentTypeID = pd.PaymentTypeID,
                                      CreateTime = pd.CreateTime,
                                      PayInAmount = pd.PayInAmount,
                                      Amount = pd.Amount,
                                      PaymentID = pd.PaymentID
                                  };

                foreach (var item in paymentTypeList1)
                {
                    var temp = querySingle.Where(x => x.PaymentTypeID == item.ID).AsQueryable();
                    if (item.ID == 170)   //挂账
                    {
                        hashTable_sum.Add(item.ID, temp.Sum(p => (decimal?)p.Amount).GetValueOrDefault());
                        hashTable_count.Add(item.ID, temp.Count(p => p.PaymentTypeID == item.ID));

                    }
                    else
                    {
                        hashTable_sum.Add(item.ID, temp.Sum(p => (decimal?)p.PayInAmount).GetValueOrDefault());
                        hashTable_count.Add(item.ID, temp.GroupBy(p => p.PaymentID).EFCount());

                        sumTotal += temp.Sum(p => (decimal?)p.PayInAmount).GetValueOrDefault();
                        countTotal += temp.GroupBy(p => p.PaymentID).EFCount();
                    }
                }

                //单查会员卡
                var paymentTypeList2 = db.cuspaymenttype.Where(p => new int[] { 151, 152, 153, 154, 155 }.Contains(p.ID)).Select(p => new { p.ID, p.Title }).ToList();
                var mSum = (decimal?)0;
                var mCount = (int?)0;
                foreach (var item in paymentTypeList2)
                {
                    var temp = querySingle.Where(x => x.PaymentTypeID == item.ID).AsQueryable();
                    mSum += temp.Sum(p => (decimal?)p.PayInAmount).GetValueOrDefault();
                    mCount += temp.Count(p => p.PaymentTypeID == item.ID);
                }

                //预定收入
                var _reserve = "预定";
                var rSum = (decimal?)0;
                var rCount = (int?)0;
                if (_reserve.IsNotNull())
                {
                    rSum += (querycusreserve.Sum(p => (decimal?)p.DepositPrice).GetValueOrDefault() - querycusreserve.Sum(p => (decimal?)p.BackDepositPrice).GetValueOrDefault());
                    rCount += querycusreserve.Count(p => p.ShopID == ShopId);
                }

                //挂账还款
                var hkSum = (decimal?)0;
                var hkCount = (int?)0;
                var querySingleBill = from rp in querycusrepayment
                                      join rpd in db.cusrepaymentdetail on rp.ID equals rpd.RePaymentID into _rpd
                                      from __rpd in _rpd.DefaultIfEmpty()
                                      join p in querycuspayment on __rpd.PaymentID equals p.ID into _p
                                      from __p in _p.DefaultIfEmpty()
                                      select new
                                      {
                                          hkMoney = rp.Money,
                                      };

                hkSum = querySingleBill.Sum(p => (decimal?)p.hkMoney).GetValueOrDefault();
                hkCount = querySingleBill.EFCount();

                var list = "";
                var exdata = new
                {
                    SumTotal = sumTotal + mSum + hkSum,
                    CountTotal = countTotal + mCount + hkCount,
                    Data_sum = hashTable_sum,
                    Data_count = hashTable_count,
                    s110 = hashTable_sum[110],
                    s140 = hashTable_sum[140],
                    s120 = hashTable_sum[120],
                    s130 = hashTable_sum[130],
                    sMember = mSum,
                    s100 = hashTable_sum[100],
                    s190 = hashTable_sum[190],
                    s200 = hashTable_sum[200],
                    s170 = hashTable_sum[170],
                    s180 = hashTable_sum[180],
                    sGzhk = hkSum,
                    sReserve = rSum,

                    c110 = hashTable_count[110],
                    c140 = hashTable_count[140],
                    c120 = hashTable_count[120],
                    c130 = hashTable_count[130],
                    cMember = mCount,
                    c100 = hashTable_count[100],
                    c190 = hashTable_count[190],
                    c200 = hashTable_count[200],
                    c170 = hashTable_count[170],
                    c180 = hashTable_count[180],
                    cGzhk = hkCount,
                    cReserve = rCount
                };
                return ToPageWithPaging(list, 0, exdata);
            }
        }


        public ActionResult OmOrOperationDetail()
        {
            ViewBag.ddlRoom = MySelect.ToSelectOrigin(MySelect.getRoom(ShopId), "", "选择房间");
            return View();
        }

        /// <summary>
        /// 房间联动餐桌
        /// </summary>
        /// <param name="roomID">房间ID</param>
        /// <returns></returns>
        public JsonResult GetTableList(string roomID)
        {
            var res = new JsonResult();
            var list = MySelect.getTable(roomID);
            res.Data = list;
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }

        public string getOmOrOperationDetail(string SumTotal,string keyword, string table, int ordermodel, int state, string st, string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                var querycuspayment = db.cuspayment.Where(x => x.ShopID == ShopId).AsQueryable();
                var querycuspaymentassociatedorders = db.cuspaymentassociatedorders.Where(x => x.ShopId == ShopId).AsQueryable();
                var querycusorder = db.cusorder.Where(x => x.ShopID == ShopId).AsQueryable();

                DateTime _st = DateTime.Now.Date.AddDays(-1);
                if (st.IsNotNull())
                {
                    _st = DateTime.Parse(st);
                    querycuspayment = querycuspayment.Where(x => x.PayFinishTime >= _st);
                }
                DateTime _et = DateTime.Now;
                if (et.IsNotNull())
                {
                    _et = DateTime.Parse(et);
                    querycuspayment = querycuspayment.Where(x => x.PayFinishTime <= _et);
                }

                var querySingle = from p in querycuspayment
                                  join pao in querycuspaymentassociatedorders on p.ID equals pao.PaymentID
                                  join o in querycusorder on pao.OrderID equals o.ID
                                  join m in db.selmanager on p.SellerID equals m.ID
                                  group new { p, pao, o, m } by p.ID
                                  into g
                                  where g.Any()
                                  select new
                                  {
                                      ID = g.Key,
                                      CreateTime = g.Select(y => y.p.CreateTime),
                                      TotalPrice = g.Select(y => y.p.TotalPrice),
                                      CardDiscountAmount = g.Select(y => y.p.CardDiscountAmount),
                                      CardDiscountScale = g.Select(y => y.p.CardDiscountScale),
                                      SmallDiscount = g.Select(y => y.p.SmallDiscount),
                                      Payable = g.Select(y => y.p.Payable),
                                      Paid = g.Select(y => y.p.Paid).FirstOrDefault(),
                                      PayState = g.Select(y => y.p.PayState).FirstOrDefault(),
                                      SellerName = g.Select(y => y.m.NickName).FirstOrDefault(),
                                      OrderID = g.Select(y => y.o.ID),
                                      OrderSource = g.Select(y => y.o.OrderSource).FirstOrDefault(),
                                      TableName=g.Select(y=>y.o.TableName).FirstOrDefault(),
                                  };

                ///查询数据
                if (keyword.IsNotNull())
                {
                    querySingle = querySingle.Where(x => x.SellerName.Contains(keyword));
                }
                if (table.IsNotNull())
                {
                    querySingle = querySingle.Where(x => x.TableName.Equals(table));
                }
                if (ordermodel > 0)
                {
                    querySingle = querySingle.Where(x =>x.OrderSource== ordermodel);
                }
                if (state > -1)
                {
                    querySingle = querySingle.Where(x => x.PayState == state);
                }

                var total = querySingle.LongCount();

                ///取当页数据列表
                var list = querySingle.OrderByDescending(x => x.ID).Skip(start).Take(length).ToList().Select(x => new
                {
                    ID = x.ID,
                    TableName = db.cuspaymentassociatedorders.Where(y => y.PaymentID.Equals(x.ID)).Select(y => new { db.cusorder.FirstOrDefault(z => z.ID == y.OrderID).ID, db.cusorder.FirstOrDefault(z => z.ID == y.OrderID).TableName }).ToArray(),
                    CreateTime = x.CreateTime.FirstOrDefault(),
                    TotalPrice = x.TotalPrice.FirstOrDefault(),
                    CardDiscountAmount = x.CardDiscountAmount.FirstOrDefault(),
                    CardDiscountScale = x.CardDiscountScale.FirstOrDefault(),
                    SmallDiscount = x.SmallDiscount.FirstOrDefault(),
                    Payable = x.Payable.FirstOrDefault(),
                    Paid = x.Paid,
                    PayState = x.PayState,
                    SellerName = x.SellerName,
                    OrderID = x.OrderID,
                    PaymentType = db.cuspaymentdetail.Where(y => y.PaymentID == x.ID).Select(y => new { db.cuspaymenttype.FirstOrDefault(z=>z.ID==y.PaymentTypeID).Title }).ToArray(),
                }).ToList();



                #region 弃用 

                //var querySingle = from pao in querycuspaymentassociatedorders
                //                  group pao by pao.PaymentID into g
                //                  join p in querycuspayment on g.Key equals p.ID
                //                  //join o in querycusorder on g.Select(x => x.OrderID).FirstOrDefault() equals o.ID
                //                  select new
                //                  {
                //                      ID = g.Key,
                //                      CreateTime = p.CreateTime,
                //                      TotalPrice = p.TotalPrice,
                //                      CardDiscountAmount = p.CardDiscountAmount,
                //                      CardDiscountScale = p.CardDiscountScale,
                //                      SmallDiscount = p.SmallDiscount,
                //                      Payable = p.Payable,
                //                      Paid = p.Paid,
                //                      PayState = p.PayState,
                //                      SellerName = db.selmanager.FirstOrDefault(x => x.ID == p.SellerID).LoginName,
                //                      OrderSource = g.FirstOrDefault().OrderID,
                //                      OrderID =g.FirstOrDefault().OrderID
                //                  };
                ////LogHelper.Log.Info(querySingle);
                /////查询数据
                //if (keyword.IsNotNull())
                //{
                //    querySingle = querySingle.Where(x => x.SellerName.Contains(keyword));
                //}
                ////if (table.IsNotNull())
                ////{

                ////    querySingle = querySingle.Where(x => x.TableID.Equals(table));
                ////}
                //if (ordermodel.IsNotNull())
                //{
                //    //list = from c in list
                //    //       from d in c.TableName
                //    //       where d.Equals(pa.SearchTxt)
                //    //       select c;
                //    //querySingle = querySingle.Where(x => x.OrderSource.Equals(ordermodel));
                //    querySingle = from a in querySingle
                //                  from b in a.OrderSource.ToString()
                //                  where b.Equals(ordermodel)
                //                  select a;
                //}
                //if (state>-1)
                //{
                //    querySingle = querySingle.Where(x => x.PayState==state);
                //}

                //var total = querySingle.LongCount();

                /////取当页数据列表
                //var list = querySingle.OrderByDescending(x => x.ID).Skip(start).Take(length).ToList().Select(x => new
                //{
                //    ID = x.OrderSource,
                //    TableName = db.cuspaymentassociatedorders.Where(y => y.PaymentID == x.ID).Select(y => new { db.cusorder.FirstOrDefault(z => z.ID == y.OrderID).ID, db.cusorder.FirstOrDefault(z => z.ID == y.OrderID).TableName }).ToArray(),
                //    CreateTime = x.CreateTime,
                //    TotalPrice = x.TotalPrice,
                //    CardDiscountAmount = x.CardDiscountAmount,
                //    CardDiscountScale = x.CardDiscountScale,
                //    SmallDiscount = x.SmallDiscount,
                //    Payable = x.Payable,
                //    Paid = x.Paid,
                //    PayState = x.PayState,
                //    SellerName = x.SellerName,
                //    OrderID = x.OrderID,
                //    OrderSource = x.OrderSource

                //}).ToList();

                #endregion


                var sumTotal = (decimal?)0;
                sumTotal = querySingle.Sum(p => (decimal?)p.Paid).GetValueOrDefault();
                //var sumTotal = SumTotal;
                var countTotal = (int?)0;
                countTotal = querySingle.GroupBy(p => p.ID).EFCount();
                var exdata = new { SumTotal = sumTotal, CountTotal = countTotal, ST = _st.ToShortDateString(), ET = _et.ToShortDateString() };
                return ToPageWithPaging(list, (int)total, exdata);

            }
        }


        public ActionResult OmOrOdPayDetail(string paymentid)
        {
            using (var db = new EFContext())
            {
                var p = db.cuspayment.FirstOrDefault(a => a.ID == paymentid);

                if (p != null)
                {
                    ViewBag.ID = p.ID;
                    ViewBag.CreateTime = p.CreateTime;
                    //var pao = db.cuspaymentassociatedorders.Where(x => x.PaymentID == paymentid);
                    //IList<cusorder> querycusorder = db.cusorder.Where(x => x.ShopID == ShopId).ToList();
                    //var tables = "";

                    //var tableList = pao.Join(querycusorder, x => x.OrderID, y => y.ID, (x, y) => new
                    //{
                    //    payid = x.PaymentID,
                    //    orders = y
                    //});
                    //foreach (var item in tableList)
                    //{
                    //    foreach (var order in item.orders)
                    //    {

                    //    }
                    //}
                    var paydetail = db.cuspaymentdetail.Where(x => x.PaymentID == p.ID);
                    var orderid = db.cuspaymentassociatedorders.FirstOrDefault(x => x.PaymentID == paymentid)?.OrderID;
                    var querycusorder = db.cusorder.FirstOrDefault(o => o.ID == orderid);
                    var tableArray = db.cuspaymentassociatedorders.Where(y => y.PaymentID == p.ID).Select(y => new { db.cusorder.FirstOrDefault(z => z.ID == y.OrderID).TableID, db.cusorder.FirstOrDefault(z => z.ID == y.OrderID).TableName }).ToArray();
                    var tableids = "";
                    var tablenames = "";
                    foreach (var item in tableArray)
                    {
                        tableids += item.TableID + " ,";
                        tablenames += item.TableName + ",";
                    }
                    tableids = tableids.Substring(0, tableids.Length - 1);
                    ViewBag.TableName = tablenames.Substring(0, tablenames.Length - 1);
                    var OrderSource="";
                    switch (querycusorder.OrderSource)
                    {
                        case 1:
                            OrderSource = "用户点餐";
                            break;
                        case 3:
                            OrderSource = "餐吧点餐";
                            break;
                        case 4:
                            OrderSource = "服务员点餐";
                            break;
                    }
                    ViewBag.OrderSource = OrderSource;//收银
                    ViewBag.SellerName = db.selmanager.FirstOrDefault(x => x.ID == p.SellerID)?.NickName;//收银员
                    ViewBag.TotalPrice = p.TotalPrice;
                    ViewBag.DiscountName = p.DiscountName;
                    ViewBag.CardDiscountAmount = p.CardDiscountAmount;
                    ViewBag.DiscountScale = p.DiscountScale;
                    ViewBag.SmallDiscount = p.SmallDiscount;
                    ViewBag.TotalPrice = p.TotalPrice;
                    ViewBag.ResourMoney = querycusorder?.ResourMoney;
                    ViewBag.Payable = p.Payable;

                    //会员卡
                    decimal? Ysdj = 0;//预收定金
                    foreach (var item in tableids.Split(','))
                    {
                        Ysdj += db.cusreserve.FirstOrDefault(x => x.ShopID == ShopId && x.TableID == item)?.DepositPrice;
                    }
                    ViewBag.Ysdj = Ysdj;
                    ViewBag.Ye = paydetail.FirstOrDefault(x => x.PaymentTypeID == 100)?.PayInAmount;
                    ViewBag.YhqMoney = paydetail.FirstOrDefault(x => x.PaymentTypeID == 200)?.PayInAmount;
                    ViewBag.YhqCode = paydetail.FirstOrDefault(x => x.PaymentTypeID == 200)?.BatchId;
                    ViewBag.ChqMoney = paydetail.FirstOrDefault(x => x.PaymentTypeID == 190)?.PayInAmount;
                    ViewBag.ChqCode = paydetail.FirstOrDefault(x => x.PaymentTypeID == 190)?.BatchId;
                    ViewBag.IsUsedCard = p.IsUsedCard ? "有" : "无";


                    //第一次收款
                    var cuspaymentdetail = db.cuspaymentdetail.FirstOrDefault(x => x.PaymentID == p.ID && x.PaymentTypeID != 170);

                    if (p.IsUsedCard)//会员卡
                    {
                        ViewBag.FPaymentType = p.IsUsedCard ? "会员卡" : "";
                        //第一次收款
                        ViewBag.FPayInAmount = cuspaymentdetail.PayInAmount;
                        var selcard = db.selcardaccount.FirstOrDefault(x => x.CardID == p.CardID);
                        var cususer = db.cususer.FirstOrDefault(x => x.UserId == selcard.UserId);
                        ViewBag.FUserName = cususer.UserName;
                        ViewBag.FPhone = cususer.Phone;
                        ViewBag.FCardType = db.selcardtype.FirstOrDefault(x => x.ID == selcard.CardTypeID).Title;
                        ViewBag.FCardID = selcard.CardID;
                        ViewBag.Fzf = "";
                        //第二次收款
                        var Squerycuspayment = db.cuspayment.Where(x => x.ID == paymentid && x.PayState == 1 && x.IsUsedCard == true);
                        var SquerySingle = from cp in Squerycuspayment
                                           join crpd in db.cusrepaymentdetail on cp.ID equals crpd.PaymentID
                                           select crpd;
                        if (SquerySingle.Any())
                        {
                            ViewBag.IsGuaZhang = "是";
                            var cusrepayment = db.cusrepayment.FirstOrDefault(x => x.ID == SquerySingle.FirstOrDefault(y => y.RePaymentID == x.ID).RePaymentID);
                            ViewBag.Money = cusrepayment.Money;
                            ViewBag.RepaymentName = cusrepayment.RepaymentName;
                            ViewBag.RepaymentPhone = cusrepayment.RepaymentPhone;
                            ViewBag.Remark = cusrepayment.Remark;
                        }
                        else
                        {
                            ViewBag.IsGuaZhang = "否";
                        }
                    }
                    else//非会员卡
                    {
                        ViewBag.FPayInAmount = cuspaymentdetail?.PayInAmount;
                        if (cuspaymentdetail.PaymentTypeID == 110)  //现金
                        {
                            //第一次收款
                            ViewBag.FPaymentType = "现金";
                            ViewBag.FAmount = cuspaymentdetail?.Amount;
                            ViewBag.FChange = cuspaymentdetail.Change;
                        }
                        else if (cuspaymentdetail.PaymentTypeID == 130)//微信
                        {
                            ViewBag.FPaymentType = "微信";
                            ViewBag.FBatchId = cuspaymentdetail.BatchId;
                        }
                        else if (cuspaymentdetail.PaymentTypeID == 120)//支付宝
                        {
                            ViewBag.FPaymentType = "支付宝";
                            ViewBag.FBatchId = cuspaymentdetail.BatchId;

                        }
                        else if (cuspaymentdetail.PaymentTypeID == 180)//免单
                        {
                            ViewBag.FPaymentType = "免单";
                            ViewBag.FPayInAmount = cuspaymentdetail.PayInAmount;
                        }
                        //第二次收款
                        var Squerycuspayment = db.cuspayment.Where(x => x.ID == paymentid && x.PayState == 1 && x.IsUsedCard == false);
                        var SquerySingle = from cp in Squerycuspayment
                                           join crpd in db.cusrepaymentdetail on cp.ID equals crpd.PaymentID
                                           select crpd;
                        if (SquerySingle.Any())
                        {
                            ViewBag.SIsGuaZhang = "是";
                            var cusrepayment = db.cusrepayment.FirstOrDefault(x => x.ID == SquerySingle.FirstOrDefault(y => y.RePaymentID == x.ID).RePaymentID);
                            ViewBag.SMoney = cusrepayment.Money;
                            ViewBag.SRepaymentName = cusrepayment.RepaymentName;
                            ViewBag.SRepaymentPhone = cusrepayment.RepaymentPhone;
                            ViewBag.SRemark = cusrepayment.Remark;
                        }
                        else
                        {
                            ViewBag.SIsGuaZhang = "否";
                        }
                    }
                }
            }
            return View();
        }
        public ActionResult OmOrOdTableDetail(string paymentid, string orderid)
        {
            ViewModel model = new ViewModel();

            using (var db = new EFContext())
            {
                var payment = db.cuspayment.FirstOrDefault(a => a.ID == paymentid);
                var order = db.cusorder.FirstOrDefault(a => a.ID == orderid);

                ViewBag.ID = order.ID;
                ViewBag.CreateTime = order.CreateTime;
                ViewBag.CompleteOrderTime = order.CompleteOrderTime;
                ViewBag.RoomName = db.selroom.FirstOrDefault(a => a.ShopID == ShopId && a.ID == db.seltable.FirstOrDefault(b => b.ID == order.TableID).RoomID).RoomName;
                ViewBag.TableName = order.TableName;
                ViewBag.PeopleCount = order.PeopleCount;
                switch (order.OrderSource)
                {
                    case 1:
                        ViewBag.OrderSource = "用户点餐";
                        break;
                    case 3:
                        ViewBag.OrderSource = "吧台点餐";
                        break;
                    case 4:
                        ViewBag.OrderSource = "服务员点餐";
                        break;
                }
                ViewBag.OrderPrice = order.OrderPrice; //菜品金额
                var user = db.cususer.FirstOrDefault(a => a.UserId == order.UserId);
                ViewBag.UserName = user?.UserName;
                ViewBag.Phone = user?.Phone;
                ViewBag.Discount = db.selshopdiscount.FirstOrDefault(x => x.ID == order.DiscountAmountStr)?.Title;//点餐优惠
                ViewBag.FoodTaste1 = order.FoodTaste1Remark; //客人口味
                ViewBag.FoodTaste2 = order.FoodTaste2Remark; //客人忌口
                ViewBag.Introduction = order.Introduction;

                var querycusorderdetail = db.cusorderdetail.Where(x => x.OrderID == orderid).AsQueryable();
                var list = from od in querycusorderdetail
                           join ofd in db.cusorderfooddetail on od.ID equals ofd.OrderDetailID into _ofd
                           from __ofd in _ofd.DefaultIfEmpty()
                           select new ViewOrderFood
                           {
                               FoodName = od.Name,
                               FoodTypeName = __ofd.FoodTypeName,
                               FoodSpecificationsName = __ofd.FoodSpecificationsName,
                               GoodsCount = od.GoodsCount,
                               GoodsPrice = od.GoodsPrice,
                               GoodsTotalPrice = (decimal)od.GoodsTotalPrice,
                               AddType = (int)__ofd.AddType
                           };
                model.ListOrder = list.ToList();
                return View(model);
            }
        }
    }
}