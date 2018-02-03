using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 材料单位
    /// </summary>
    public class ExMaterialUnit
    {         
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
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 上次价格
        /// </summary>
        public decimal LastPrice { get; set; }
        /// <summary>
        /// 均价
        /// </summary>
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public decimal CountReal { get; set; }

    }
}
