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
   
    public class PaVerification
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
