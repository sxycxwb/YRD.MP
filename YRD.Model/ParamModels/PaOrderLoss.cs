using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 提交报损单主表
    /// </summary>
    public class PaOrderLoss:PaBase
    {
        /// <summary>
        /// 报损单ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 报损原因
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 库房ID
        /// </summary>
        public string WarehouseID { get; set; }
    }
}
