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
    /// 电子券消费统计表
    /// </summary>
    public partial class statisticscoupons
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
        /// 券类型
        /// </summary>
        public string CouponsType { get; set; }
        /// <summary>
        /// 领取数量
        /// </summary>
        public int CouponsReceiveNumber { get; set; }
        /// <summary>
        /// 领取总额
        /// </summary>
        public decimal CouponsReceiveMount { get; set; }
        /// <summary>
        /// 赠送数量
        /// </summary>
        public int CouponsGiveNumber { get; set; }
        /// <summary>
        /// 赠送总额
        /// </summary>
        public decimal CouponsGiveMount { get; set; }
        /// <summary>
        /// 核销次数
        /// </summary>
        public int CouponsUseNumber { get; set; }
        /// <summary>
        /// 核销总额
        /// </summary>
        public decimal CouponsUseMount { get; set; }
        /// <summary>
        /// 核销率
        /// </summary>
        public decimal CouponsUseRatio { get; set; }
        /// <summary>
        /// 时间标识
        /// </summary>
        public string TimeFlag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
       
    }
}


