using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 操作员密码
    /// </summary>
    public class PaPwd : PaBase
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPwd { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPwd { get; set; }
    }
}
