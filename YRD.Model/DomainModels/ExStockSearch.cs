using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 库存统计总额
    /// </summary>
    public class ExStockSearchTotal
    { 
        /// <summary>
        /// 原料种类 
        /// </summary>
        public int TypeCount { get; set; } 
        /// <summary>
        /// 原料总额
        /// </summary>
        public decimal Money { get; set; }
    }
    /// <summary>
    /// 库存统计原料详情
    /// </summary>
    public class ExMStockDetail
    {
        /// <summary>
        /// 原料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string MaterialTypeName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string MaterialSpecName { get; set; }       
        /// <summary>
        /// 库房
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
