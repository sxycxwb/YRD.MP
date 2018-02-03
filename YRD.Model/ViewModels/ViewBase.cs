using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class ViewBase : Base
    {
        /// <summary>
        /// 登录超时时需要给Url赋值
        /// </summary>
        public string Url { get; set; }
    }
}
