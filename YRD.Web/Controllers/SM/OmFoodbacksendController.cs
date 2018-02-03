using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.Web.Controllers
{
    public class OmFoodbacksendController : BaseController
    {
        // GET: OmFoodbacksend
        public ActionResult OmFoodbacksendRecord()
        {
            return View();
        }
        public string getOmFoodbacksendRecord(string keyword,int type,string st,string et, int start, int length)
        {
            using (var db = new EFContext())
            {
                var querycusorder = db.cusorder.Where(x => x.ShopID == ShopId).AsQueryable();
                var querycusorderfooddetail = db.cusorderfooddetail.Where(x => x.AddType > 1).AsQueryable();

                DateTime _st = DateTime.Now.Date.AddDays(-1);
                if (st.IsNotNull())
                {
                    _st = DateTime.Parse(st);
                    querycusorder = querycusorder.Where(x => x.CompleteOrderTime >= _st);
                }
                DateTime _et = DateTime.Now;
                if (et.IsNotNull())
                {
                    _et = DateTime.Parse(et);
                    querycusorder = querycusorder.Where(x => x.CompleteOrderTime <= _et);
                } 

                var querySingle = from ofd in querycusorderfooddetail 
                                  join od in db.cusorderdetail on ofd.OrderDetailID equals od.ID into _od
                                  from __od in _od.DefaultIfEmpty()
                                  join or in querycusorder on __od.OrderID equals or.ID into _or
                                  from __or in _or.DefaultIfEmpty()
                                  join m in db.selmanager on __or.SellerID equals m.ID into _m
                                  from __m in _m.DefaultIfEmpty()
                                  select new
                                  {
                                      ID=ofd.ID,
                                      OrderID = __or.ID,
                                      AddType = ofd.AddType,
                                      ConfirmOrderTime = __or.ConfirmOrderTime,
                                      TableName = __or.TableName,
                                      FoodName = ofd.FoodName,
                                      FoodAttributeName = ofd.FoodAttributeName,
                                      GoodsPrice = __od.GoodsPrice,
                                      GoodsCount = __od.GoodsCount,//点餐数量
                                      FoodCount = ofd.FoodCount,//退赠数量
                                      FoodTotalPrice = __od.GoodsPrice* ofd.FoodCount, //退增金额
                                      SellerName = __m.LoginName, 
                                      Remark= ofd.Remark,
                                  };

                ///查询数据
                if (keyword.IsNotNull())
                {
                    querySingle = querySingle.Where(x => x.OrderID.Contains(keyword) || x.FoodName.Contains(keyword));
                }
                if (type != 0)
                {
                    querySingle = querySingle.Where(x => x.AddType == type);
                }

                var total = querySingle.EFCount();

                ///取当页数据列表
                var query = querySingle.OrderByDescending(x => x.ID).Skip(start).Take(length).ToList().Select(x => new
                {
                    ID = x.ID,
                    OrderID = x.OrderID,
                    AddType = x.AddType,
                    ConfirmOrderTime = x.ConfirmOrderTime,
                    TableName = x.TableName,
                    FoodName = x.FoodName,
                    FoodAttributeName = x.FoodAttributeName,
                    GoodsPrice = x.GoodsPrice,
                    GoodsCount = x.GoodsCount,
                    FoodCount = x.FoodCount,
                    FoodTotalPrice = x.FoodTotalPrice,
                    SellerName = x.SellerName,
                    Remark=x.Remark,
                });
                var exdata = new { ST = _st.ToShortDateString(), ET = _et.ToShortDateString() };
                var list = query.ToList();
                return ToPageWithPaging(list, total, exdata);
            }
        }
    }
}