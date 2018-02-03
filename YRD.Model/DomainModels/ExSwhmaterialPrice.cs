using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 仓库材料表详情
    /// </summary>
    public class ExSwhmaterialPrice
    {
        /// <summary>
        /// 表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string MaterialPackageUnitName { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 均价
        /// </summary>
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public Nullable<float> CountNum { get; set; }
        /// <summary>
        /// 包装数量
        /// </summary>
        public decimal PackBudget { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public decimal TotalPriceReal { get; set; }
    }
}
