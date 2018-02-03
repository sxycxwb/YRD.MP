using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.Web.Controllers
{
    public class OmHangrePaymentController : BaseController
    {
        // GET: OmHangrePayment
        public ActionResult OmHangrePaymentRecord()
        {
            //ViewBag.dllDebt = MySelect.ToSelectOrigin(MySelect.getOrderDebt(ShopId), "", "选择挂账人");
            return View();
        }
        public string getOmHangrePaymentRecord(string keyword, int state, string debt, string st, string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                var querycuspayment = db.cuspayment.Where(x => x.ShopID == ShopId).AsQueryable();
                var querycuspaymentdetail = db.cuspaymentdetail.Where(x => x.PaymentTypeID == 170).AsQueryable();
                var queryrepayment = db.cusrepayment.Where(x => x.PaymentTypeID > 0).AsQueryable();

                DateTime _st = DateTime.Now.Date.AddDays(-1);
                if (st.IsNotNull())
                {
                    _st = DateTime.Parse(st);
                    querycuspayment = querycuspayment.Where(x => x.CreateTime >= _st);
                    querycuspaymentdetail = querycuspaymentdetail.Where(x => x.CreateTime >= _st);
                    queryrepayment = queryrepayment.Where(x => x.CreateTime >= _st);
                }
                DateTime _et = DateTime.Now;
                if (et.IsNotNull())
                {
                    _et = DateTime.Parse(et);
                    querycuspayment = querycuspayment.Where(x => x.CreateTime <= _et);
                    querycuspaymentdetail = querycuspaymentdetail.Where(x => x.CreateTime <= _et);
                    queryrepayment = queryrepayment.Where(x => x.CreateTime <= _et);
                }
                var querySingle = from pd in querycuspaymentdetail
                                  join p in querycuspayment on pd.PaymentID equals p.ID into _p
                                  from __p in _p.DefaultIfEmpty()
                                  select new
                                  {
                                      ID = __p.ID,
                                      PaymentDetailID = pd.ID,
                                      CreateTime = __p.CreateTime,
                                      Payable = __p.Payable,
                                      Bill = pd.Amount,
                                      DebtName = pd.DebtName,
                                      DebtPhone = pd.DebtPhone,
                                      PayState = __p.PayState,
                                      PayInAmount = pd.PayInAmount,
                                  };

                ///查询数据
                if (keyword.IsNotNull())
                {
                    querySingle = querySingle.Where(x => x.ID.Contains(keyword) || x.DebtName.Contains(keyword) || x.DebtPhone.Contains(keyword));
                }
                if (state != -1)
                {
                    querySingle = querySingle.Where(x => x.PayState == state);
                }
                if (debt.IsNotNull())
                {
                    querySingle = querySingle.Where(x => x.DebtName == debt);
                }

                var total = querySingle.EFCount();

                ///取当页数据列表
                var query = querySingle.OrderByDescending(x => x.ID).Skip(start).Take(length).ToList().Select(x => new
                {
                    ID = x.ID,
                    CreateTime = x.CreateTime,
                    Payable = x.Payable,
                    Bill = x.Bill,
                    DebtName = x.DebtName,
                    DebtPhone = x.DebtPhone,
                    PayState = x.PayState,
                    State = db.cusrepaymentdetail.FirstOrDefault(y => y.PaymentDetailID == x.PaymentDetailID) != null ? 1 : 0,
                });

                var queryrepaymentSingle = from rp in queryrepayment
                                           join rpd in db.cusrepaymentdetail on rp.ID equals rpd.RePaymentID into _rpd
                                           from __rpd in _rpd.DefaultIfEmpty()
                                           join p in querycuspayment on __rpd.PaymentID equals p.ID into _p
                                           from __p in _p.DefaultIfEmpty()
                                           select new
                                           {
                                               PayState = __p.PayState,
                                               Payable = __p.Payable,
                                               Paid = __p.Paid,
                                               money = rp.Money,
                                           };

                var billTotal = db.cuspayment.Where(x => x.PayState == 0).Sum(x => (decimal?)(x.Payable - x.Paid)).GetValueOrDefault();//挂账总额
                var huankuan = queryrepaymentSingle.Where(x => x.PayState == 1).Sum(x => (decimal?)x.money).GetValueOrDefault();//还款
                var qiankuan = queryrepaymentSingle.Where(x => x.PayState == 0).Sum(x => (decimal?)(x.Payable - x.Paid)).GetValueOrDefault();//欠款

                var exdata = new { ST = _st.ToShortDateString(), ET = _et.ToShortDateString(), billTotal = billTotal, huankuan = huankuan, qiankuan = qiankuan };
                var list = query.ToList();
                return ToPageWithPaging(list, total, exdata);
            }
        }

        public ActionResult OmHangrePaymentDetail(string paymentid)
        {
            using (var db = new EFContext())
            {
                var payment = db.cuspayment.FirstOrDefault(x => x.ID == paymentid);
                var paymentdetail = db.cuspaymentdetail.FirstOrDefault(x => x.PaymentID == paymentid && x.PaymentTypeID == 170);
                ViewBag.ID = payment.ID;
                ViewBag.CreateTime = payment.CreateTime;
                ViewBag.Payable = payment.Payable;
                ViewBag.Bill = paymentdetail.Amount;
                ViewBag.DebtName = paymentdetail.DebtName;
                ViewBag.DebtPhone = paymentdetail.DebtPhone;

                var repaymentID = db.cusrepaymentdetail.FirstOrDefault(y => y.PaymentID == paymentid).RePaymentID;
                var repayment = db.cusrepayment.FirstOrDefault(x => x.ID == repaymentID);
                ViewBag.hkMoney = repayment.Money;
                ViewBag.hkCreateTime = repayment.CreateTime;

                return View();
            }
        }
    }
}