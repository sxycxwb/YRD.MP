using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 登陆类型
    /// </summary>
    public class PaLoginSmall
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; } 
    }
    /// <summary>
    /// 登陆类型
    /// </summary>
    public class PaLogin
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string code { get; set; }

        public PaVerification Verification { get; set; }
    }
}
