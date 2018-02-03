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

    public partial class selshopversion
    {
        /// <summary>
        /// 店铺升级记录表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ManagerID { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 版本ID
        /// </summary>
        public int VersionID { get; set; }

        /// <summary>
        /// 是否续费
        /// </summary>
        public int ReNew { get; set; }
        /// <summary>
        /// 开通时间
        /// </summary>
        public System.DateTime StartTime { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public System.DateTime EndTime { get; set; }
        /// <summary>
        /// 购买月数
        /// </summary>
        public int MonthCount { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayMode { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 0 提交成功 1支付成功
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 支付回调时间
        /// </summary>
        public Nullable<System.DateTime> ConfirmDT { get; set; }
        /// <summary>
        /// 支付批处理编号
        /// </summary>
        public string BatchId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}

