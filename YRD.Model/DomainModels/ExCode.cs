using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class ExCode
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string codes { get; set; }
    }

    /// <summary>
    /// 验证
    /// </summary>
    public class ExVerification
    {
        /// <summary>
        /// 验证码编号
        /// </summary>
        public string VerificationId { get; set; }

        /// <summary>
        /// 验证码值
        /// </summary>
        public string VerificationCode { get; set; }
    }
}
