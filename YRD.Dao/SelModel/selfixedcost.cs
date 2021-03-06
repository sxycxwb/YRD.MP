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
    
    public partial class selfixedcost
    {
        /// <summary>
        /// 店铺固定费用表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<int> IsDel { get; set; }
        /// <summary>
        /// 创建管理员ID
        /// </summary>
        public string CreateManagerID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 固定费用类型（1按桌收2按人数收）
        /// </summary>
        public Nullable<int> Type { get; set; }
        /// <summary>
        /// 参数1
        /// </summary>
        public Nullable<decimal> Parameter1 { get; set; }
        /// <summary>
        /// 参数2
        /// </summary>
        public Nullable<decimal> Parameter2 { get; set; }
        /// <summary>
        /// 参数3
        /// </summary>
        public Nullable<decimal> Parameter3 { get; set; }
        /// <summary>
        /// 参数4
        /// </summary>
        public Nullable<decimal> Parameter4 { get; set; }
        /// <summary>
        /// 参数5
        /// </summary>
        public Nullable<decimal> Parameter5 { get; set; }
        /// <summary>
        /// 参数6
        /// </summary>
        public Nullable<decimal> Parameter6 { get; set; }
    }
}


