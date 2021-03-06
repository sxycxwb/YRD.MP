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

    public partial class selshopsmsrecharge
    {
        /// <summary>
        /// 充值编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ManagerID { get; set; }
        /// <summary>
        /// 短信条数
        /// </summary>
        public int SmsCount { get; set; }
        /// <summary>
        /// 购买花费金额
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 充值时间
        /// </summary>
        public System.DateTime DT { get; set; }
        /// <summary>
        /// 充值类型  0 提交充值 1充值成功
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsAvailable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BatchId { get; set; }
        /// <summary>
        /// 充值到账时间
        /// </summary>
        public Nullable<System.DateTime> ConfirmDT { get; set; }
    }
}


