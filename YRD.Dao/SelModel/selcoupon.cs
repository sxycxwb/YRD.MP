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

    public partial class selcoupon
    {
        /// <summary>
        /// 优惠券表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string CouponName { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 满X送Y中的X
        /// </summary>
        public decimal FullAmount { get; set; }
        /// <summary>
        /// 满X送Y中的Y
        /// </summary>
        public decimal SetAmount { get; set; }
        /// <summary>
        /// 折扣比例 9.2折  存0.92
        /// </summary>
        public decimal DiscountScale { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public System.DateTime StartTime { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public System.DateTime EndTime { get; set; }
        /// <summary>
        /// 最低消费
        /// </summary>
        public decimal MinConsumption { get; set; }
        /// <summary>
        /// 店铺优惠类型（1满送代金券2满送折扣券）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 规则类型(1推广2餐后）
        /// </summary>
        public int RuleType { get; set; }
        /// <summary>
        /// 优惠劵规则定义的使用期限单位"月"
        /// </summary>
        public int RuleUserTimeSpan { get; set; }
        /// <summary>
        /// 是否允许批量结账使用
        /// </summary>
        public bool IsAllowBatch { get; set; }
        /// <summary>
        /// 使用时间
        /// </summary>
        public Nullable<System.DateTime> UsingTime { get; set; }
        /// <summary>
        /// 核销工作人员ID
        /// </summary>
        public string SellerID { get; set; }
    }
}

