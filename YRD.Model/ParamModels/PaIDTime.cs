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
    public class PaIDTime : PaBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 订单类别
        /// </summary>
        public string OrderTypeID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime starTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime endTime { get; set; }
    }
}
