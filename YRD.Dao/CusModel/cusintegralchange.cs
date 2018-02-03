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
    
    public partial class cusintegralchange
    {
        /// <summary>
        /// 用户积分变化表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public Nullable<int> UserID { get; set; }
        /// <summary>
        /// 变化类型（1增加2减少）
        /// </summary>
        public Nullable<int> ChangeType { get; set; }
        /// <summary>
        /// 变化积分
        /// </summary>
        public Nullable<int> ChangeIntegration { get; set; }
        /// <summary>
        /// 变化名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}


