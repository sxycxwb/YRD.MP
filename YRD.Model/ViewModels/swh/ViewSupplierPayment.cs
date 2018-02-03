using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    //1现金2支付宝3微信4银行卡5支票6转账
    /// <summary>
    /// 付款
    /// </summary>
    public class ViewSupplierPayment
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 付款名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 支付方式（1现金2支付宝3微信4银行卡5支票6转账）
        /// </summary>
        public int PayMode { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public int Data { get; set; }
        /// <summary>
        /// 支付完成凭证图片
        /// </summary>

        public string CompletePaymentImage { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public ViewSupplier ViewSupplier { get; set; }

    }

}
