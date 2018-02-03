using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 报损订单，购物车统一提交
    /// </summary>
    public class PaOrderLossRateWhole : PaBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 简介,报损原因
        /// </summary>
        public string Introduction { get; set; }      
        /// <summary>
        /// 库房id
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public List<OrderLossRateWholeDetail> Detail { get; set; }
    }
    /// <summary>
    /// 报损订单，购物车统一提交--详情
    /// </summary>
    public class OrderLossRateWholeDetail
    {
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Number { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        public string UnitID { get; set; }

    }
}
