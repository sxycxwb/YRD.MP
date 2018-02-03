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
    public class PaOrderType : PaBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单类别
        /// </summary>
        public string OrderType { get; set; }
    }
}
