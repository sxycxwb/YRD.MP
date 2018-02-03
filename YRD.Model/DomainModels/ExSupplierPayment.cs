using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 付款单
    /// </summary>
    public class ExSupplierPayment
    {
        /// <summary>
        /// 材料供应商结账表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }        
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 支付方式（1现金2支付宝3微信4银行卡5支票6转账）
        /// </summary>
        public string PayMode { get; set; }
        /// <summary>
        /// 金额标识 正数为1负数-1
        /// </summary>

        public int Sign { get; set; }
        /// <summary>
        /// 支付的金额
        /// </summary>
        public decimal Data { get; set; } 
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 支付完成凭证图片
        /// </summary>
        public string CompletePaymentImage { get; set; }
        /// <summary>
        /// 经手人
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 变化名称
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 付款账号
        /// </summary>
        public string BankNo { get; set; }

    }
}
