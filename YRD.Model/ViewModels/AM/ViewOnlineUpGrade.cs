using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewOnlineUpGrade
    {
        /// <summary>
        /// 
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 店铺Vip等级（1免费版）
        /// </summary>
        public int VersionID { get; set; }
        /// <summary>
        /// 店铺Vip等级（1免费版）
        /// </summary> 
        public string VersionText { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>

        public string EndTime { get; set; }
        /// <summary>
        /// 是否开启库存
        /// </summary> 
        public int IsWarehouse { get; set; }

        /// <summary>
        /// 库存开始时间
        /// </summary>
        public string WarehouseStartTime { get; set; }
        /// <summary>
        /// 库存结束时间
        /// </summary>

        public string WarehouseEndTime { get; set; }

        public decimal Price1 { get; set; }

        public int TableMaxCount1 { get; set; }

        public int PrintMaxCount1 { get; set; }

        public int CashierMaxCount1 { get; set; }

        public decimal Price2 { get; set; }

        public int TableMaxCount2 { get; set; }

        public int PrintMaxCount2 { get; set; }

        public int CashierMaxCount2 { get; set; }


        public decimal Price3 { get; set; }

        public int TableMaxCount3 { get; set; }

        public int PrintMaxCount3 { get; set; }

        public int CashierMaxCount3 { get; set; }


        public decimal Price4 { get; set; }

        public string TableMaxCount4 { get; set; }

        public string PrintMaxCount4 { get; set; }

        public int CashierMaxCount4 { get; set; }


        public decimal Price6 { get; set; }

        public int TableMaxCount6 { get; set; }

        public int PrintMaxCount6 { get; set; }

        public int CashierMaxCount6 { get; set; }

    }

    public class ViewOnlineUpGradePayment
    {
        public string BatchId { get; set; }

        /// <summary>
        /// 总共价格
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartTimeFormat { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>

        public string EndTimeFormat { get; set; }

        public string Remark { get; set; }

        public string PayPassword { get; set; }

        public int VersionID { get; set; }
    }
}
