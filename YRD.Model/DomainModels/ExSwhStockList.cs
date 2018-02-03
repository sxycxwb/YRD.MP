using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 库存明细数据列表
    /// </summary>
    public class ExSwhStockList
    {
        /// <summary>
        /// 仓库材料表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 菜名
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string MaterialTypeName { get; set; }
        /// <summary>
        /// 本周出货数量
        /// </summary>
        public decimal ThisWeekCount { get; set; }
        /// <summary>
        /// 本月出货数量
        /// </summary>
        public decimal ThisMonthCount { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StockCount { get; set; }
    }
}
