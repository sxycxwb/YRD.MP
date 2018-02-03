using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 库存搜索条件
    /// </summary>
    public class PaIndexStockSearch : PaPageList
    {
        /// <summary>
        /// 原料名称
        /// </summary>
        public string MatrialName { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// 原料分类 id
        /// </summary>
        public string Type1 { get; set; }
        /// <summary>
        /// 原料子类id
        /// </summary>
        public string Type2 { get; set; }
        /// <summary>
        /// 原料ID
        /// </summary>
        public string MatrialID { get; set; }
        /// <summary>
        /// 排序字段 1：原料名称，2：库存数量 3：库存总额
        /// </summary>
        public int OrderBy { get; set; }
        /// <summary>
        /// 正序或倒序 1：正序，2：倒序
        /// </summary>
        public int OrderAsc { get; set; }
    }     
}
