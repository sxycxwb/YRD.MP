using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 今日入库，出库 金额
    /// </summary>
    public class ExTodayMoney
    {
        /// <summary>
        /// 今日入库金额
        /// </summary>
        public decimal InMoney { get; set; }
        /// <summary>
        /// 今日出库金额
        /// </summary>
        public decimal OutMoney { get; set; }
        /// <summary>
        /// 今日盘点金额
        /// </summary>
        public decimal CheckMoney { get; set; }
    }
}
