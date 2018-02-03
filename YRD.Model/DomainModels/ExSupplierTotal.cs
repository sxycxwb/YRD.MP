using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 获取全部供应商，应付供应商与欠款总额
    /// </summary>
    public class ExSupplierTotal
    {
        /// <summary>
        /// 全部供应商数
        /// </summary>
        public int AllCount { get; set; }
        /// <summary>
        /// 应付供应商数
        /// </summary>
        public int PayCount { get; set; }
        /// <summary>
        /// 欠款总额 
        /// </summary>
        public decimal PayMoneyTotal { get; set; }
    }
    /// <summary>
    /// 本期付款，退货，总欠汇总
    /// </summary>
    public class ExSupplierTotalPay
    {
        /// <summary>
        /// 本期付款
        /// </summary>
        public decimal PayCount { get; set; }
        /// <summary>
        /// 本期退货
        /// </summary>
        public decimal TuiCount { get; set; }
        /// <summary>
        /// 欠款总额 
        /// </summary>
        public decimal PayMoneyTotal { get; set; }
    }
}
