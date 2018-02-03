using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.Web.Controllers
{
    public class OmSubscribeController : BaseController
    {
        // GET: OmSubscribe
        public ActionResult OmSubscribeRecord()
        {
            return View();
             
        }

        public string getOmSubscribeRecord(int state, int source, string keyword, string st, string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                var querycusreserve = db.cusreserve.Where(x => x.ShopID == ShopId).AsQueryable();

                DateTime _st = DateTime.Now.Date.AddDays(-1);
                if (st.IsNotNull())
                {
                    _st = DateTime.Parse(st);
                    querycusreserve = querycusreserve.Where(x => x.CreateTime >= _st);
                }
                DateTime _et = DateTime.Now;
                if (et.IsNotNull())
                {
                    _et = DateTime.Parse(et);
                    querycusreserve = querycusreserve.Where(x => x.CreateTime <= _et);
                }
                var querySingle = from or in querycusreserve
                                  join o in db.cusorder on or.ID equals o.ID into _o
                                  from __o in _o.DefaultIfEmpty()
                                  join m in db.selmanager on or.SellerID equals m.ID into _m
                                  from __m in _m.DefaultIfEmpty()
                                  join p in db.syspaymentmode on or.PayMode equals p.ID into _p
                                  from __p in _p.DefaultIfEmpty()
                                  select new
                                  {
                                      ID = or.ID,
                                      TableName = __o.TableName,
                                      CreateDate = or.CreateDate,
                                      SellerName = __m.LoginName,
                                      OrderSource = or.OrderSource,
                                      CustomerName = or.CustomerName,
                                      CustomerPhone = or.CustomerPhone,
                                      ReserveCount = or.ReserveCount,
                                      DepositPrice = or.DepositPrice,
                                      PayMode = __p.Title,
                                      ReserveState = or.ReserveState,
                                  };

                ///查询数据
                if (keyword.IsNotNull())
                {
                    querySingle = querySingle.Where(x => x.CustomerName.Contains(keyword) || x.CustomerPhone.Contains(keyword));
                }
                if (state!=0)
                {
                    querySingle = querySingle.Where(x => x.ReserveState== state);
                }
                if (source!=0)
                {
                    querySingle = querySingle.Where(x => x.OrderSource== source);
                }

                var total = querySingle.EFCount();

                ///取当页数据列表
                var query = querySingle.OrderByDescending(x => x.ID).Skip(start).Take(length).ToList().Select(x => new
                {
                    ID = x.ID,
                    TableName = x.TableName,
                    CreateDate = x.CreateDate,
                    SellerName = x.SellerName,
                    OrderSource = x.OrderSource,
                    CustomerName = x.CustomerName,
                    CustomerPhone = x.CustomerPhone,
                    ReserveCount = x.ReserveCount,
                    DepositPrice = x.DepositPrice,
                    PayMode = x.PayMode,
                    ReserveState = x.ReserveState,

                });
                var exdata = new { ST = _st.ToShortDateString(), ET = _et.ToShortDateString() };
                var list=query.ToList();
                return ToPageWithPaging(list, total, exdata);
            }
        }
    }
}