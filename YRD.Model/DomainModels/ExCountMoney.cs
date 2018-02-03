using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 分单的 已入库单数与金额
    /// </summary>
    public class ExCountMoney
    {
        /// <summary>
        /// 已入库单数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
    }
}
