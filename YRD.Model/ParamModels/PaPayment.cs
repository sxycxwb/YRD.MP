using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 付款
    /// </summary>
    public class PaPayment : PaBase
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 付款方式 1现金 2支付宝 3微信 4银行卡 5支票 6转账
        /// </summary>
        public int PayMode { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 金额标识，正数=1  负数=-1
        /// </summary>
        public int Sign { get; set; } = 1;
        /// <summary>
        /// 付款凭证图片（苹果使用）
        /// </summary>
        public byte[] Img { get; set; }
        /// <summary>
        /// 付款凭证图片（安卓上使用）
        /// </summary>
        public string ImgBase64 { get; set; }
        /// <summary>
        /// 图片后缀格式，比如：.png(带上前面的.)
        /// </summary>
        public string ImgType { get; set; }
    }
}
