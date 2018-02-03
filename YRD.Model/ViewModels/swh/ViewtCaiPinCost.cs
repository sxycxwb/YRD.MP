using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    /// <summary>
    /// 菜品费用
    /// </summary>
    public class ViewCaiPinCost
    {
        /// <summary>
        /// 菜品编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }
        /// <summary>
        /// 0 半成品 1 成品
        /// </summary>
        public int FinishType { get; set; }
        /// <summary>
        /// 0 无 1 有
        /// </summary>
        public int IsTeJia { get; set; }
        /// <summary>
        /// 菜品分类
        /// </summary>
        public string FoodType { get; set; }
        /// <summary>
        /// 是否是套餐（1是0否）
        /// </summary>
        public bool IsPackage { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Manager { get; set; }
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string PrintName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 列表图url
        /// </summary>
        public string ListImgUrl { get; set; }
        /// <summary>
        /// 是否有规格
        /// </summary>
        public int IsHavePecification { get; set; }
        /// <summary>
        /// 菜品单位编号
        /// </summary>
        public string FoodUnitID { get; set; }
        /// <summary>
        /// 菜品单位名称
        /// </summary>
        public string FoodUnitName { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecTitle { get; set; }
        /// <summary>
        /// 规格编号
        /// </summary>

        public string FoodSpecificationsID { get; set; }
        /// <summary>
        /// 普通价格
        /// </summary>
        public decimal PriceGeneral { get; set; }
        /// <summary>
        /// 会员价格
        /// </summary>
        public decimal PriceVip { get; set; }
        /// <summary>
        /// 特价价格
        /// </summary>
        public decimal PriceSpecial { get; set; }
        /// <summary>
        /// 外卖价
        /// </summary>
        public decimal PriceTakeOut { get; set; }

        /// <summary>
        /// 主料平均值
        /// </summary>
        public decimal MainMaterialAveragePrice { get; set; }

        /// <summary>
        /// 辅料平均值
        /// </summary>
        public decimal AuxiliaryMaterialAveragePrice { get; set; }

        /// <summary>
        /// 菜品总成本
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 是否编辑
        /// </summary>
        public bool IsEdit { get; set; }

    }

}
