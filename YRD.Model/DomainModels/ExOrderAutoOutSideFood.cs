using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 销售出库 菜品明细
    /// </summary>
    public class ExOrderAutoOutSideFood
    {
        /// <summary>
        /// 有无套餐 0：无  1：有
        /// </summary>
        public int IsPackage { get; set; }
        /// <summary>
        /// 菜品 名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 菜品类型
        /// </summary>
        public string FoodTypeName { get; set; }
        /// <summary>
        /// 菜品规格
        /// </summary>
        public string FoodSpecificationsName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int FoodCount { get; set; }
        /// <summary>
        /// 菜品单位
        /// </summary>
        public string FoodUnit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? FoodPrice { get; set; }
        /// <summary>
        /// 销售总价
        /// </summary>
        public decimal? TotalPrice { get; set; }
        /// <summary>
        /// 库房
        /// </summary>
        public string Warehouse { get; set; }
        /// <summary>
        /// 主料金额
        /// </summary>
        public decimal? ZhuLiaoMoney { get; set; }
        /// <summary>
        /// 辅料金额
        /// </summary>
        public decimal? FuLiaoMoney { get; set; }
        /// <summary>
        /// 销售利润
        /// </summary>
        public decimal? Profit { get; set; }
        /// <summary>
        /// 主料明细
        /// </summary>
        public List<DetailLiao> ZhuLiaoList { get; set; }
        /// <summary>
        /// 辅料明细
        /// </summary>
        public List<DetailLiao> FuLiaoList { get; set; }
    }
    /// <summary>
    /// 主料或辅料
    /// </summary>
    public class DetailLiao
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        public decimal Total { get; set; }
    }

}
