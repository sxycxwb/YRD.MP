using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 仓库内部领料申请表详情
    /// </summary>
    public class ExSwhorderinsidedetail
    {
        /// <summary>
        /// 表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string MaterialSpecName { get; set; }
        /// <summary>
        /// 均价
        /// </summary>
        //public decimal PriceAge { get; set; }
        /// <summary>
        /// 预算数量
        /// </summary>
        public decimal CountBudget { get; set; }
        /// <summary>
        /// 预算价格
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 小计预算金额
        /// </summary>
        public decimal TotalPriceBudget { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 小计实际金额
        /// </summary>
        public decimal TotalPriceReal { get; set; }
        /// <summary>
        /// 库内数量
        /// </summary>
        public decimal StockCount { get; set; }
        /// <summary>
        /// 单位换算
        /// </summary>
        public decimal UnitScale { get; set; }
    }
}
