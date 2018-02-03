using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRD.Model.ViewModels;

namespace YRD.Web.Controllers
{
    public class BusinessIncomeController : BaseController
    {
        // GET: Test
        public ActionResult OmOperationRecord()
        {
            var sumTotal = (decimal?)0;//营收总金额
            var countTotal = (decimal?)0;//营收总单数
            using (var db = new EFContext())
            { 
                //不包含会员卡
                Hashtable hashTable_sum = new Hashtable();
                Hashtable hashTable_count = new Hashtable();
                var paymentTypeList1 = db.cuspaymenttype.Where(p=>!new int[] { 151, 152, 153, 154, 155 }.Contains(p.ID)).Select(p => new { p.ID, p.Title }).ToList();
                foreach (var item in paymentTypeList1)
                {
                    var sumTemp = db.cuspaymentdetail.Where(p => p.PaymentTypeID == item.ID).Sum(p => (decimal?)p.Amount).GetValueOrDefault();
                    var countTemp=  db.cuspaymentdetail.Count(p=>p.PaymentTypeID==item.ID);
                    hashTable_sum.Add(item.ID, sumTemp);
                    hashTable_count.Add(item.ID, countTemp);

                    sumTotal += sumTemp;
                    countTotal += countTemp;
                }
                ViewBag.Data_sum = hashTable_sum;
                ViewBag.Data_count = hashTable_count;

                //单查会员卡
                var paymentTypeList2 = db.cuspaymenttype.Where(p => new int[] { 151, 152, 153, 154, 155 }.Contains(p.ID)).Select(p => new { p.ID, p.Title }).ToList();
                var mSum = (decimal?)0;
                var mCount = (decimal?)0;
                foreach (var item in paymentTypeList2)
                {
                    mSum +=db.cuspaymentdetail.Where(p => p.PaymentTypeID == item.ID).Sum(p => (decimal?)p.Amount).GetValueOrDefault();
                    mCount += db.cuspaymentdetail.Count(p => p.PaymentTypeID == item.ID);
                }
                ViewBag.MemberCardSum = mSum;
                ViewBag.MemberCardCount = mCount;

                
                ViewBag.SumTotal = sumTotal + mSum;
                ViewBag.CountTotal = countTotal + mCount;
            }
            return View();
        } 
    }
 
}
