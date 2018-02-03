using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 供应商付款方式
    /// </summary>
    public class ExSupplierPaymode
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 微信账号
        /// </summary>
        public string WeiXinPay { get; set; }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string AliPay { get; set; }
        /// <summary>
        /// 开户人姓名
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 开户银行名称
        /// </summary>
        public string BankDeposit { get; set; }
    }
}
