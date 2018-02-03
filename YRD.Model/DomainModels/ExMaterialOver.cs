using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 物料预警
    /// </summary>
    public class ExMaterialOver
    {
        /// <summary>
        /// 菜名 物料名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 预警下限
        /// </summary>
        public int Min { get; set; }
        /// <summary>
        /// 预警上限
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// 当前库存
        /// </summary>
        public decimal Count { get; set; }
    }
}
