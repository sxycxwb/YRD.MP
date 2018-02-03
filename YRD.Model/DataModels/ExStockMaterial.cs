using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 材料简类
    /// </summary>
    public class ExMaterialSimple
    {
        /// <summary>
        /// 材料ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 材料名称 
        /// </summary>
        public string Title { get; set; }

    }
    /// <summary>
    /// 库存材料详情
    /// </summary>
    public class ExStockMaterial
    {
        /// <summary>
        /// 仓库材料表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 材料名称（不能重复）
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 规格名称（相当于备注功能）
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 库房ID
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StockNum { get; set; }

        /// <summary>
        /// 平均价
        /// </summary>
        public decimal AveragePrice { get; set; }

        /// <summary>
        /// 最近供货价
        /// </summary>
        public decimal LastPrice { get; set; }
       
        /// <summary>
        /// 最大价格
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// 最小价格
        /// </summary>
        public decimal MinPrice { get; set; }
        ///// <summary>
        ///// 排序
        ///// </summary>
        //public int Sort { get; set; }
    }
}
