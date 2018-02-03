using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Model.SwhModels;

namespace YRD.Model
{
    /// <summary>
    /// 显示盘点表详情
    /// </summary>
    public class ExOrderCheckDetail
    {
        /// <summary>
        /// 仓库盘点申请表详情ID
        /// </summary>
        public string ID { get; set; }       
        /// <summary>
        /// 盘点表ID
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
        public string MaterialSpecName { get; set; }
        
        /// <summary>
        /// 计量单位编号
        /// </summary>
        public string MaterialUnitID { get; set; }
        /// <summary>
        /// 计量单位名称 也是盘点单位
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 主计量单位名称
        /// </summary>
        public string MaterialMainUnitName { get; set; }
        /// <summary>
        /// 主计量单位ID
        /// </summary>
        public string MaterialMainUnitID { get; set; }

        /// <summary>
        /// 预算数量
        /// </summary>
        public decimal CountBudget { get; set; }
        
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StockCount { get; set; } 
        /// <summary>
        /// 单位换算
        /// </summary>
        public decimal UnitScale { get; set; }
    }
    /// <summary>
    /// 盘点详情+材料计量单位列表
    /// </summary>
    public class ExOrderCheckDetailWithUnit: ExOrderCheckDetail
    {
        /// <summary>
        /// 计量单位列表
        /// </summary>
        public List<ExBaseModel> UnitList { get; set; }
    }
}
