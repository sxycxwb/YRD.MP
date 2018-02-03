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
    public class ExSwhmaterial
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
        /// 单位ID
        /// </summary>
        public string MaterialUnitID { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 参考价
        /// </summary>
        public decimal ReferPrice { get; set; }
        /// <summary>
        /// 上次价格
        /// </summary>
        public decimal LastPrice { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public decimal CountReal { get; set; }      
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
    }
}
