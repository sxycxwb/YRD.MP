using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 报损出库汇总单数
    /// </summary>
    public class ExLossRateSearchTotal
    {
        /// <summary>
        /// 报损单数
        /// </summary>
        public int OrderCount { get; set; }
        /// <summary>
        /// 报损种类 
        /// </summary>
        public int TypeCount { get; set; }
        ///// <summary>
        ///// 报损数量
        ///// </summary>
        //public decimal Number { get; set; }
        /// <summary>
        /// 报损总额
        /// </summary>
        public decimal Money { get; set; }
    }
    /// <summary>
    /// 报损 列表
    /// </summary>
    public class ExLossRateSearchList : ExApplySearchBase
    {
        /// <summary>
        /// 详情列表
        /// </summary>
        public List<ExLossRateDetail> Detail { get; set; }
    }
    /// <summary>
    /// 报损详情
    /// </summary>
    public class ExLossRateDetail
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
        /// 损耗率(报损里不需要)
        /// </summary>
        public decimal LossRate { get; set; }
        /// <summary>
        /// 报损人（损耗统计里不需要）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 出库库房
        /// </summary>
        public string WarehouseName { get; set; }
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
