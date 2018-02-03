using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 报损申请简易数据列表
    /// </summary>
    public class PaBaseModelLossRateList : PaBase
    {
        /// <summary>
        /// 报损表详情ID，添加时不用填写，api生成
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderApplyID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 材料单位ID
        /// </summary>
        public string MaterialUnitID { get; set; }
        /// <summary>
        /// 实际单价
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 预算数量
        /// </summary>
        public decimal CountBudget { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 预算价格
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 损失数量
        /// </summary>
        public decimal CountLoss { get; set; }
        
            
            
            
    }
}
