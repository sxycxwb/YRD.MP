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

    public partial class selcashier
    {
        /// <summary>
        /// 收银台ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 备用金
        /// </summary>
        public Nullable<decimal> PettyCash { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> CreateTime { get; set; }
    }
}


