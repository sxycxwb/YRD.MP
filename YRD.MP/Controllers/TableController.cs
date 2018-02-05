using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.MP.Controllers
{
    /// <summary>
    /// 餐桌业务控制器
    /// </summary>
    public class TableController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region 实时状态

        /// <summary>
        /// 区域 楼层信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDeprtmentList()
        {
            using (var db = new EFContext())
            {
                var query = db.seldepartment.Where(x => x.ShopID == ShopID).OrderBy(x => x.Sort).AsQueryable();
                var list = from data in query
                           select new
                           {
                               ID = data.ID,
                               Name = data.Title
                           };
                string json = ToPageNoPaging(query.ToList());
                return Content(json);
            }
        }

        /// <summary>
        /// 房间信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoomList(string departmentID)
        {
            using (var db = new EFContext())
            {
                var query = db.selroom.Where(x => x.ShopID == ShopID).AsQueryable();
                if (!string.IsNullOrEmpty(departmentID))
                    query = query.Where(x => x.DepartmentID == departmentID);
                query = query.OrderBy(x => x.Sort);
                var list = from data in query
                           select new
                           {
                               ID = data.ID,
                               Name = data.RoomName
                           };
                string json = ToPageNoPaging(query.ToList());
                return Content(json);
            }
        }

        /// <summary>
        /// 获取房间信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoomList(string departmentID, string roomID)
        {
            using (var db = new EFContext())
            {
                var query = from r in db.selroom
                            join t in db.seltable on r.ID equals t.RoomID into r1
                            from a in r1
                            join s in db.seltablestate on a.ID equals s.TableID into r2
                            from b in r2.DefaultIfEmpty()
                            select new
                            {
                                DepartmentID = r.DepartmentID,
                                RoomID = r.ID,
                                TableName = a.TableName,
                                TableState = b.TableState,
                                TableSort = a.Sort
                            };
                if (!string.IsNullOrEmpty(departmentID))
                    query = query.Where(x => x.DepartmentID == departmentID);
                if (!string.IsNullOrEmpty(roomID))
                    query = query.Where(x => x.RoomID == roomID);
                query = query.OrderBy(x => x.TableSort);
                string json = ToPageNoPaging(query.ToList());
                return Content(json);
            }
        }

        #endregion

        #region 开台率
        public ActionResult GetOpenTableData(string beginDate, string endDate)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticstable.Where(x => x.ShopID == ShopID);
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate))
                    .OrderBy(x => x.TimeFlag);

                var list = from data in query
                           select new
                           {
                               TotalOpenTableNumber = data.TotalOpenTableNumber,
                               OpenTableRate = data.OpenTableRate,
                               Date = data.TimeFlag
                           };

                var dataList = list.ToList();
                int totalOpenNum = dataList.Sum(x => x.TotalOpenTableNumber);
                decimal averageOpenRate = dataList.Sum(x => x.OpenTableRate) / dataList.Count();
                var exdata = new
                {
                    totalOpenNum = totalOpenNum,
                    averageOpenRate = averageOpenRate
                };
                string json = ToPageNoPaging(dataList, exdata);
                return Content(json);
            }
        }
        #endregion

        #region 上座率
        public ActionResult GetUpperlimbData(string beginDate, string endDate)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticstable.Where(x => x.ShopID == ShopID);
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate))
                    .OrderBy(x => x.TimeFlag);

                var list = from data in query
                           select new
                           {
                               TotalPeopleNumber = data.TotalPeopleNumber,
                               Upperlimb = data.Upperlimb,
                               Date = data.TimeFlag
                           };

                var dataList = list.ToList();
                int totalPeopleNum = dataList.Sum(x => x.TotalPeopleNumber);
                decimal averageUpperlimb = dataList.Sum(x => x.Upperlimb) / dataList.Count();
                var exdata = new
                {
                    totalPeopleNum = totalPeopleNum,
                    averageUpperlimb = averageUpperlimb
                };
                string json = ToPageNoPaging(dataList, exdata);
                return Content(json);
            }
        }
        #endregion

        #region 翻台率
        public ActionResult GetTurnoverData(string beginDate, string endDate)
        {
            using (var db = new EFContext())
            {
                var query = db.statisticstable.Where(x => x.ShopID == ShopID);
                query = query.Where(x => Convert.ToDateTime(x.TimeFlag) >= Convert.ToDateTime(beginDate) && Convert.ToDateTime(x.TimeFlag) <= Convert.ToDateTime(endDate))
                    .OrderBy(x => x.TimeFlag);

                var list = from data in query
                           select new
                           {
                               TurnoverNum = data.TurnoverNum,
                               TurnoverRate = data.TurnoverRate,
                               Date = data.TimeFlag
                           };

                var dataList = list.ToList();
                int totalTurnoverNum = dataList.Sum(x => x.TurnoverNum);
                decimal averageTurnoverRate = dataList.Sum(x => x.TurnoverRate) / dataList.Count();
                var exdata = new
                {
                    totalTurnoverNum = totalTurnoverNum,
                    averageTurnoverRate = averageTurnoverRate
                };
                string json = ToPageNoPaging(dataList, exdata);
                return Content(json);
            }
        }
        #endregion
    }
}