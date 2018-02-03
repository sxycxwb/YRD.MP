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
    
    public partial class cusrepayment
    {
        /// <summary>
        /// 还款编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public int PaymentTypeID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 还款人名称
        /// </summary>
        public string RepaymentName { get; set; }
        /// <summary>
        /// 还款人手机号
        /// </summary>
        public string RepaymentPhone { get; set; }

        /// <summary>
        /// 操作员编号
        /// </summary>
        public string SellerID { get; set; }
    }
}


