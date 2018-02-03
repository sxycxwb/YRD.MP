using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 短信参数
    /// </summary>
    public class PaSms
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 短信参数 以Json的形式，短信模版上面有几个参数就传几个
        /// 如短信模版：验证码 ${number}，欢迎使用美味云点
        /// 参数：{\"number\":\"6532\"}
        /// </summary>
        public string SmsParam { get; set; }

        /// <summary>
        /// 短信模版编号 对应短信模版表syssmstemplate
        /// </summary>
        public int TemplateID { get; set; }

        /// <summary>
        /// 网商编号 如果短信模版是商家 必传
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 安全码 SafeCodeHelper.GetSafeCode
        /// </summary>
        public string SafeCode { get; set; }
    }
}
