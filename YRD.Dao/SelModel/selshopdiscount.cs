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

    public partial class selshopdiscount
    {
        /// <summary>
        /// 店铺优惠表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 会员卡规则名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 满X减Y中的X
        /// </summary>
        public decimal FullAmount { get; set; }
        /// <summary>
        /// 满X减Y中的Y
        /// </summary>
        public decimal SetAmount { get; set; }
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
        /// 折扣比例
        /// </summary>
        public decimal DiscountScale { get; set; }
        /// <summary>
        /// 店铺优惠类型（1满减2折扣）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 是否允许批量 
        /// </summary>

        public bool IsAllowBatch { get; set; }
    }
}

