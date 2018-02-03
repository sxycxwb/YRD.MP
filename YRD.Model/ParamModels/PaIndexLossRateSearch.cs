using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 退货出库统计条件
    /// </summary>
    public class PaIndexLossRateSearch : PaDate
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 原料名称
        /// </summary>
        public string MatrialName { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WarehouseID { get; set; }
        
        /// <summary>
        /// 原料分类 
        /// </summary>
        public string Type1 { get; set; }
        /// <summary>
        /// 原料子类
        /// </summary>
        public string Type2 { get; set; }
        /// <summary>
        /// 排序字段 1：耗损比例，2：耗损数量 3:报损金额
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary>
        /// 正序或倒序 1：正序，2：倒序
        /// </summary>
        public int OrderAsc { get; set; }
    }
    /// <summary>
    /// 日期搜索，带分页
    /// </summary>
    public class PaPageIndexLossRateSearch : PaIndexLossRateSearch
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
