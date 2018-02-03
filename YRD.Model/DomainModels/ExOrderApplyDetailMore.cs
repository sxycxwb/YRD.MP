using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 采购入库明细数据列表
    /// </summary>
    public class ExOrderApplyDetailMore : ExOrderApplyDetail
    {
        /// <summary>
        /// 平均价
        /// </summary>
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// 最近单价
        /// </summary>
        public decimal LastPrice { get; set; }
        ///// <summary>
        ///// 预算单价， 提交单价
        ///// </summary>
        //public decimal PriceBudget { get; set; } 
        /// <summary>
        /// 核准价格
        /// </summary>
        public decimal PriceCheck { get; set; }
        /// <summary>
        /// 核准数量
        /// </summary>
        public decimal CountCheck { get; set; }
        /// <summary>
        /// 默认数量（减去已入库数量），入库时要填写的数量的默认值
        /// </summary>
        public decimal DefaultCount { get; set; }

    }
}
