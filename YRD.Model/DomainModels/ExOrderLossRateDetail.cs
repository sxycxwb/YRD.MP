using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 报损详情
    /// </summary>
    public class ExOrderLossRateDetail
    {
        /// <summary>
        /// 仓库损耗申请表详情ID
        /// </summary>
        public string ID { get; set; }       
        /// <summary>
        /// 报损申请表ID
        /// </summary>
        public string OrderApplyID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }       
        /// <summary>
        /// 材料规格名称
        /// </summary>
        public string SpecName { get; set; }        
        /// <summary>
        /// 库房名
        /// </summary>
        public string WareHouseName { get; set; }
        /// <summary>
        /// 库房id
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 损失数量
        /// </summary>
        public decimal CountLoss { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StockCount { get; set; }
        /// <summary>
        /// 计量单位编号
        /// </summary>
        public string MaterialUnitID { get; set; }
        /// <summary>
        /// 计量单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }        
        
        /// <summary>
        /// 预算金额/库内均价
        /// </summary>
        public decimal PriceBudget { get; set; }      
        /// <summary>
        /// 小计预算金额
        /// </summary>
        public decimal TotalPriceBudget { get; set; }
        /// <summary>
        /// 单位换算
        /// </summary>
        public decimal UnitScale { get; set; }

    }
}
