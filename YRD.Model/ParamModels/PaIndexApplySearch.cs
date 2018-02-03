using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 带排序字段的简单搜索
    /// </summary>
    public class PaIndexApplySearch1 : PaPageListDate
    {
        /// <summary>
        /// 排序字段 1：原料名称，2：原料数量 3：入库总额
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary>
        /// 正序或倒序 1：正序，2：倒序
        /// </summary>
        public int OrderAsc { get; set; }
    }
    /// <summary>
    /// 日期搜索
    /// </summary>
    public class PaIndexApplySearch : PaDate
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
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 原料分类 id
        /// </summary>
        public string Type1 { get; set; }
        /// <summary>
        /// 原料子类id
        /// </summary>
        public string Type2 { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleID { get; set; }
        /// <summary>
        /// 管理员姓名id
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 状态 1:审核中 2：未通过审核 3：通过审核 4：已完成
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// 排序字段 1：原料名称，2：原料数量 3：入库总额
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
    public class PaPageIndexApplySearch : PaIndexApplySearch
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
