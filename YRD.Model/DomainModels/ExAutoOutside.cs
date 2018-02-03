using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 销售出库
    /// </summary>
    public class ExOrderAutoOutside
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 菜品销售
        /// </summary>
        public decimal? FoodMoney { get; set; }
        /// <summary>
        /// 原料出库
        /// </summary>
        public decimal? MaterialMoney { get; set; }
        /// <summary>
        /// 销售利润
        /// </summary>
        public decimal? Profit { get; set; }
    }
}
