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
    
    public partial class syspayhistory
    {
        /// <summary>
        /// 
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BatchId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 0 未回调 1回调成功
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> ConfirmTime { get; set; }
    }
}

