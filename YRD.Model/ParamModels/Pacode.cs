using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class PaCode: PaBase
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string code { get; set; }
    }
}
