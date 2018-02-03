using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 采购订单，整单入库 统一提交
    /// </summary>
    public class PaOrderStorageWhole : PaBase
    {
        /// <summary>
        /// 采购订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 库房ID
        /// </summary>
        public string WarehourseID { get; set; }
        /// <summary>
        /// 0整单入库 1 分单
        /// </summary>
        public int TakeinWarehouseType { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 0 现金 1欠款
        /// </summary>
        public int PayState { get; set; }
        /// <summary>
        /// (只有分单入库时才起作用)0未完成 1已完成
        /// </summary>
        public int IsFinish { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public List<OrderStorageWholeDetail> Detail { get; set; }
    }
    /// <summary>
    /// 采购订单，入库 统一提交--详情
    /// </summary>
    public class OrderStorageWholeDetail
    {
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 采购详情ID
        /// </summary>
        public string DetailID { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 入库单价
        /// </summary>
        public decimal PriceReal { get; set; }
    }
}
