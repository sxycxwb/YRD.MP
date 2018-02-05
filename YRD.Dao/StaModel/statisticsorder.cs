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
    /// 订单日统计表
    /// </summary>
    public partial class statisticsorder
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
        /// 订单总数
        /// </summary>
        public int OrderNumber { get; set; }   
        /// <summary>
        /// 订单总计销售金额
        /// </summary>
        public decimal TotalSalesAmount { get; set; }
        /// <summary>
        /// 订单均价
        /// </summary>
        public decimal AverageAmount { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int OrderSource { get; set; }
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

