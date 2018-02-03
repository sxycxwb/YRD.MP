using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 日期搜索
    /// </summary>
    public class PaTimeSearch:PaBase
    {
        /// <summary>
        /// 供应商id
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
    /// <summary>
    /// 日期搜索，带分页
    /// </summary>
    public class PaTimePage:PaTimeSearch
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
    }
}
