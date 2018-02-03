using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    /// <summary>
    /// 付款详情
    /// </summary>
    public class ViewSupplierPaymentDetail
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 支付方式（1现金2支付宝3微信4银行卡5支票6转账）
        /// </summary>
        public int PayMode { get; set; }

        /// <summary>
        /// 支付方式（1现金2支付宝3微信4银行卡5支票6转账）
        /// </summary>
        public string PayModeName { get; set; }
        /// <summary>
        ///  金额标识 正数为1负数-1
        /// </summary>
        public int Sign { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal Data { get; set; }
        /// <summary>
        /// 支付完成凭证图片
        /// </summary>
        public string CompletePaymentImage { get; set; }
        /// <summary>
        /// 付款人
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 付款人
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 付款人
        /// </summary>
        public string OperationSellerNickName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
