using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 查询条件 时间
    /// </summary>
    public class PaPageListTime:PaPageList
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; } 
    }
}
