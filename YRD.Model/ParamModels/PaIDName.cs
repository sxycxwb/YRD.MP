using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 用于下拉的那些列表
    /// </summary>
    public class PaIDName : PaBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
    }
}
