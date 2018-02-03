using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 盘点统计条件
    /// </summary>
    public class PaIndexCheckSearch : PaDate
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
        /// 1:盘盈  -1：盘亏
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 排序字段 1：盘亏状况，2：盘亏数量 3:盘亏额度
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
    public class PaPageIndexCheckSearch : PaIndexCheckSearch
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
