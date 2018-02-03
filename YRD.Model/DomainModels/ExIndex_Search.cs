using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    /// <summary>
    /// 搜索
    /// </summary>
    public class ExIndex_Search
    {
        /// <summary>
        /// 菜名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 类别名
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 本周出货
        /// </summary>
        public decimal Out_Week { get; set; }
        /// <summary>
        /// 本月出货
        /// </summary>
        public decimal Out_Month { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal Count { get; set; }
    }
}
