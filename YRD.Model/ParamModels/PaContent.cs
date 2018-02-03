using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 提交订单审核
    /// </summary>
    public class PaContent : PaBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 内容/备注
        /// </summary>
        public string Content { get; set; }
    }
}
