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
    public class PaPrice :PaIDNumber
    {
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
