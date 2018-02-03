using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 盘点明细数据列表
    /// </summary>
    public class ExSwhOrdercheckList
    {
        /// <summary>
        /// 主表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
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
        /// 规格名称
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal CountStock { get; set; }
        /// <summary>
        /// 包装单位名称
        /// </summary>
        public string MaterialPackUnitName { get; set; }
        /// <summary>
        /// 单位数量
        /// </summary>
        public decimal UnitCountBudget { get; set; }
        /// <summary>
        /// 整包数量
        /// </summary>
        public decimal WholeCountBudget { get; set; }
        /// <summary>
        /// 零散数量
        /// </summary>
        public decimal ZeroCountBudget { get; set; }
        /// <summary>
        /// 最高进价
        /// </summary>
        public decimal PriceMax { get; set; }
        /// <summary>
        /// 最低进价
        /// </summary>
        public decimal PriceMin { get; set; }
        /// <summary>
        /// 均价
        /// </summary>
        public string PriceAge { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime createTime { get; set; }
    }
}
