using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// ID
    /// </summary>
    public class PaIDNumber : PaBase
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Number { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        public string UnitID { get; set; }
    }
}
