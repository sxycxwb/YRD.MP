﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class selcouponoperationseller
    {
        /// <summary>
        /// 商家优惠券操作记录表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 店铺操作人员ID
        /// </summary>
        public string SellerID { get; set; }
        /// <summary>
        /// 卡ID
        /// </summary>
        public string CardID { get; set; }
        /// <summary>
        /// 操作类型（1生成2禁用）
        /// </summary>
        public Nullable<int> Type { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}


