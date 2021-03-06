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
    
    public partial class swhsupplierpayment
    {
        /// <summary>
        /// 材料供应商结账表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 付款名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 支付方式（1现金2支付宝3微信4银行卡5支票6转账）
        /// </summary>
        public int PayMode { get; set; }
        /// <summary>
        /// 金额标识 正数为1负数-1
        /// </summary>
        public int Sign { get; set; }
        /// <summary>
        /// 支付金额的绝对值
        /// </summary>
        public decimal Data { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 支付完成凭证图片
        /// </summary>
        public string CompletePaymentImage { get; set; }
        /// <summary>
        /// 付款人
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 变化名称
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 开户人姓名
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 开户银行名称
        /// </summary>
        public string BankDeposit { get; set; }
    }
}


