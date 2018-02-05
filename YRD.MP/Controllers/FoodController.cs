using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.MP.Controllers
{
    /// <summary>
    /// 菜品业务控制器
    /// </summary>
    public class FoodController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region 菜品、类别获取
        /// <summary>
        /// 获取菜品类别信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetfFoodtypeList()
        {
            using (var db = new EFContext())
            {
                var query = db.selfoodtype.Where(x => x.ShopID == ShopID).OrderBy(x => x.Sort).AsQueryable();
                var list = from data in query
                           select new
                           {
                               TypeID = data.ID,
                               TypeName = data.Title
                           };
                string json = ToPageNoPaging(query.ToList());
                return Content(json);
            }
        }

        /// <summary>
        /// 获取类别下菜品信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodList(string foodTypeID)
        {
            using (var db = new EFContext())
            {
                var query = db.selfood.Where(x => x.ShopID == ShopID).AsQueryable();
                if (!string.IsNullOrEmpty(foodTypeID))
                    query = query.Where(x => x.FoodTypeID == foodTypeID);
                var list = from data in query
                           select new
                           {
                               FoodID = data.ID,
                               FoodName = data.FoodName
                           };
                string json = ToPageNoPaging(query.ToList());
                return Content(json);
            }
        }

        #endregion

        #region 菜品销售统计

        #region 菜品单项
        /// <summary>
        /// 菜品销售统计（按菜品）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodSalesList(string beginDate, string endDate, string foodID)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticsfood.Where(x => x.ShopID == ShopID && x.FoodID == foodID).AsQueryable();
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate));
                var list = query.GroupBy(x => new { x.FoodID, x.FoodName }).Select(g => new
                {
                    SalesAmount = g.Sum(x => x.SalesAmount),//总金额
                    SalesaNumber = g.Sum(x => x.SalesNumber),//总数量
                    FoodSalesMountRatio = g.Sum(x => x.FoodSalesMountRatio) / g.Count(), //销售额占比
                    FoodSalesNumberRatio = g.Sum(x => x.FoodSalesNumberRatio) / g.Count() //销售量占比
                });
                string json = ToPageNoPaging(list.ToList());
                return Content(json);
            }
        }

        /// <summary>
        /// 菜品销售明细（按菜品）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodSalesDetail(string beginDate, string endDate)
        {
            using (var db = new EFContext())
            {
                var query = db.cusorder.Where(x => x.ShopID == ShopID);



                query = query.Where(x => x.CreateTime >= Convert.ToDateTime(beginDate) && x.CreateTime <= Convert.ToDateTime(endDate));
                query.GroupBy
            }
        }

        /// <summary>
        /// 菜品销售汇总明细（按菜品）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodSalesSummaryDetail(string beginDate, string endDate)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticsfood.Where(x => x.ShopID == ShopID).AsQueryable();
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate))
                    .OrderBy(x => x.TimeFlag);
                var list = from data in query
                           select new
                           {
                               FoodID = data.ID,
                               FoodName = data.FoodName,
                               FoodSpecificationsName = data.FoodSpecificationsName,
                               FoodTypeName = data.FoodTypeName,
                               SalesAmount = data.SalesAmount,
                               SalesNumber = data.SalesNumber,
                               FoodSalesMountRatio = data.FoodSalesMountRatio,
                               FoodSalesNumberRatio = data.FoodSalesNumberRatio
                           };
                string json = ToPageNoPaging(list.ToList());
                return Content(json);
            }
        }

        /// <summary>
        /// 菜品类别销售图表（按菜品）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodSalesChart(string beginDate, string endDate, string foodID)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticsfood.Where(x => x.ShopID == ShopID && x.FoodID == foodID).AsQueryable();
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate));
                var list = query.GroupBy(x => new { x.FoodID, x.TimeFlag }).Select(g => new
                {
                    SalesAmount = g.Sum(x => x.SalesAmount),//总金额
                    SalesNumber = g.Sum(x => x.SalesNumber),//总数量
                    Date = g.Key.TimeFlag //日期
                }).ToList();

                var exdata = new
                {
                    totalSalesAmount = list.Sum(x => x.SalesAmount),
                    totalSalesNumber = list.Sum(x => x.SalesNumber)
                };
                string json = ToPageNoPaging(query.ToList(), exdata);
                return Content(json);
            }
        }
        #endregion


        #region 菜品分类
        /// <summary>
        /// 菜品类别销售统计（按分类）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodTypeSalesList(string beginDate, string endDate, string foodTypeID)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticsfoodtype.Where(x => x.ShopID == ShopID && x.FoodTypeID == foodTypeID).AsQueryable();
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate));
                var list = query.GroupBy(x => new { x.FoodTypeID }).Select(g => new
                {
                    SalesAmount = g.Sum(x => x.FoodTypeSalesAmount),//总金额
                    SalesaNumber = g.Sum(x => x.FoodTypeSalesNumber),//总数量
                    FoodSalesMountRatio = g.Sum(x => x.FoodTypeSalesRatio) / g.Count(), //销售额占比
                    FoodSalesNumberRatio = g.Sum(x => x.FoodTypeSalesNumberRatio) / g.Count() //销售量占比
                });
                string json = ToPageNoPaging(list.ToList());
                return Content(json);
            }
        }

        /// <summary>
        /// 菜品类别销售图表（按分类）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodSalesTypeDetail(string beginDate, string endDate)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticsfoodtype.Where(x => x.ShopID == ShopID).AsQueryable();
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate))
                    .OrderBy(x => x.TimeFlag);
                var list = from data in query
                           select new
                           {
                               FoodID = data.ID,
                               FoodTypeName = data.FoodTypeName,
                               SalesAmount = data.FoodTypeSalesAmount,
                               SalesNumber = data.FoodTypeSalesNumber,
                               FoodSalesMountRatio = data.FoodTypeSalesRatio,
                               FoodSalesNumberRatio = data.FoodTypeSalesNumberRatio
                           };
                string json = ToPageNoPaging(list.ToList());
                return Content(json);
            }
        }

        /// <summary>
        /// 菜品类别销售图表（按分类）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodTypeSalesChart(string beginDate, string endDate, string foodTypeID)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticsfoodtype.Where(x => x.ShopID == ShopID && x.FoodTypeID == foodTypeID).AsQueryable();
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate));
                var list = query.GroupBy(x => new { x.FoodTypeID, x.TimeFlag }).Select(g => new
                {
                    SalesAmount = g.Sum(x => x.FoodTypeSalesAmount),//总金额
                    SalesNumber = g.Sum(x => x.FoodTypeSalesNumber),//总数量
                    Date = g.Key.TimeFlag //日期
                }).ToList();

                var exdata = new
                {
                    totalSalesAmount = list.Sum(x => x.SalesAmount),
                    totalSalesNumber = list.Sum(x => x.SalesNumber)
                };
                string json = ToPageNoPaging(query.ToList(), exdata);
                return Content(json);
            }
        }

        /// <summary>
        /// 菜品类别销售图表（环形饼图）
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFoodTypeSalesChartPie(string beginDate, string endDate, string foodTypeID)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticsfoodtype.Where(x => x.ShopID == ShopID && x.FoodTypeID == foodTypeID).AsQueryable();
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate));
                var list = query.GroupBy(x => new { x.FoodTypeID, x.FoodTypeName }).Select(g => new
                {
                    FoodTypeName = g.Key.FoodTypeName, //菜品类别
                    SalesAmount = g.Sum(x => x.FoodTypeSalesAmount),//总金额
                    SalesNumber = g.Sum(x => x.FoodTypeSalesNumber),//总数量
                }).ToList();

                var exdata = new
                {
                    totalSalesAmount = list.Sum(x => x.SalesAmount),
                    totalSalesNumber = list.Sum(x => x.SalesNumber)
                };
                string json = ToPageNoPaging(query.ToList(), exdata);
                return Content(json);
            }
        }

        #endregion
        #endregion


    }
}