﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 餐桌日统计表
    /// </summary>
    public partial class statisticstable
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// 总开台数
        /// </summary>
        public int TotalOpenTableNumber { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public int TotalPeopleNumber { get; set; }
        /// <summary>
        /// 总计销售金额
        /// </summary>
        public decimal TotalSalesAmount { get; set; }
        /// <summary>
        /// 餐桌均价
        /// </summary>
        public decimal TableAveragePrice { get; set; }
        /// <summary>
        /// 午餐均价
        /// </summary>
        public decimal LunchAveragePrice { get; set; }
        /// <summary>
        /// 晚餐均价
        /// </summary>
        public decimal DinnerAveragePrice { get; set; }
        /// <summary>
        /// 餐桌预定数
        /// </summary>
        public int TotalReserveNumber { get; set; }
        /// <summary>
        /// 预定成功数
        /// </summary>
        public int ReserSuccessNumber { get; set; }
        /// <summary>
        /// 上座率
        /// </summary>
        public decimal Upperlimb { get; set; }
        /// <summary>
        /// 开台率
        /// </summary>
        public decimal OpenTableRate { get; set; }
        /// <summary>
        /// 翻台率
        /// </summary>
        public decimal TurnoverRate { get; set; }
        /// <summary>
        /// 预订率
        /// </summary>
        public decimal ReservationRate { get; set; }
        /// <summary>
        /// 预订成功率
        /// </summary>
        public decimal ReservationSuccessRate { get; set; }
        /// <summary>
        /// 时间标识
        /// </summary>
        public string TimeFlag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
       
    }
}


