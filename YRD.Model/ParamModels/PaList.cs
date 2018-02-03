using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 分页输入参数
    /// </summary>
    public class PaPageList:PaBase
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
