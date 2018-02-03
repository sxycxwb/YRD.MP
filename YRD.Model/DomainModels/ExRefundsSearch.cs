using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 退货出库汇总单数
    /// </summary>
    public class ExRefundsSearchTotal
    {
        /// <summary>
        /// 退货单数
        /// </summary>
        public int OrderCount { get; set; }
        /// <summary>
        /// 退货种类 
        /// </summary>
        public int TypeCount { get; set; }
        ///// <summary>
        ///// 退货数量
        ///// </summary>
        //public decimal Number { get; set; }
        /// <summary>
        /// 退货总额
        /// </summary>
        public decimal Money { get; set; }
    }
    /// <summary>
    /// 退货 列表
    /// </summary>
    public class ExRefundsSearchList : ExApplySearchBase
    {
        /// <summary>
        /// 详情列表
        /// </summary>
        public List<ExRefundsDetail> Detail { get; set; }
    }
    /// <summary>
    /// 退货详情
    /// </summary>
    public class ExRefundsDetail
    {
        /// <summary>
        /// 订单
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string MaterialSpecName { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 出库库房
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 库管
        /// </summary>
        public string KuGuan { get; set; }
        /// <summary>
        /// 取货人
        /// </summary>
        public string RefundName { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string RefundPhone { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public decimal Total { get; set; }
    }
}
