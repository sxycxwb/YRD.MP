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
    
    public partial class selcardrule
    {
        /// <summary>
        /// 会员卡规则ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 会员卡规则名称
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// 会员卡类型ID
        /// </summary>
        public int CardTypeID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 卡的标准价格
        /// </summary>
        public decimal StandAmount { get; set; }
        /// <summary>
        /// 购买卡时获取到的初始金额、次数
        /// </summary>
        public decimal OriginAmount { get; set; }
        /// <summary>
        /// 购买卡时获取到的额外金额、次数、打折（0.95）
        /// </summary>
        public decimal ExtentAmount { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 连锁key
        /// </summary>
        public string LinkKey { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 1启用 0停用
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}

