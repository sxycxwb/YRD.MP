using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 供应商订单简易模型
    /// </summary>
    public class ExSupplierOrder
    {
        /// <summary>
        /// 入库单ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Money { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 退货单结算状态（0：未结算   1：已结算）
        /// </summary>
        public int? State { get; set; } = 1;
    }
}
