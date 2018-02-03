using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 供应商结账流水
    /// </summary>
    public class ExSupplierMoneyDetail
    {
        /// <summary>
        /// 订单类型 1：采购进货单  2退货单  3付款单
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 结账类型
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 订单进度列表
        /// </summary>
        public List<ExProgress> Progress { get; set; }
        /// <summary>
        /// 入库库房
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 付款人
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 付款账号
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 付款凭证图片
        /// </summary>
        public string PayImage { get; set; } 

    } 

}
