using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewFood
    {
        /// <summary>
        /// 店铺菜品表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 菜名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 菜品属性1
        /// </summary>
        public string FoodAttribute1 { get; set; }

        /// <summary>
        /// 菜品属性2
        /// </summary>
        public string FoodAttribute2 { get; set; }

        /// <summary>
        /// 菜品属性3
        /// </summary>
        public string FoodAttribute3 { get; set; }
        /// <summary>
        /// 菜品属性4
        /// </summary>
        public string FoodAttribute4 { get; set; }
        /// <summary>
        /// 菜品属性5
        /// </summary>
        public string FoodAttribute5 { get; set; }
        /// <summary>
        /// 菜品属性6
        /// </summary>
        public string FoodAttribute6 { get; set; }

        /// <summary>
        /// 0 半成品 1 成品
        /// </summary>
        public int FinishType { get; set; }
        /// <summary>
        /// 0 规格 1有规格
        /// </summary>
        public int IsHavePecification { get; set; }

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

        public int TimeType { get; set; }

        public string DayValue { get; set; }



        public List<ViewFoodSpecifications> ViewFoodSpecificationsList { get; set; }

        public List<ViewFoodSelfoodspecialtime> ViewFoodSelfoodspecialtime { get; set; }



        /// <summary>
        /// 出菜时间
        /// </summary>
        public int MakeMinute { get; set; }

        /// <summary>
        /// 0 无 1 有
        /// </summary>
        public int IsTeJia { get; set; }
        /// <summary>
        /// 0 无 1 有
        /// </summary>
        public int IsPrint { get; set; }

        public string MainIngredient { get; set; }

        public string Accessories { get; set; }

        public List<ViewImgUrl> ImgUrlList { get; set; }

        public string listimgurl { get; set; }

        public string Introduction { get; set; }
    }

    public class ViewFoodSpecifications
    {
        /// <summary>
        /// 菜品规格表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 菜品ID
        /// </summary>
        public string FoodID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }
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
        /// 特价类型（1按周天2按月天）
        /// </summary>
        public int TimeType { get; set; }

        public string DayValue { get; set; }
    }

    public class ViewFoodSelfoodspecialtime
    {
        /// <summary>
        /// 商家菜品特价时间表
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 特价图片
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 菜品ID
        /// </summary>
        public string FoodID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<int> IsDel { get; set; }
        /// <summary>
        /// 特价类型（1按周天2按月天）
        /// </summary>
        public Nullable<int> Type { get; set; }
        /// <summary>
        /// 普通价格
        /// </summary>
        public Nullable<decimal> PriceGeneral { get; set; }
        /// <summary>
        /// 会员价格
        /// </summary>
        public Nullable<decimal> PriceVip { get; set; }
        /// <summary>
        /// 特价价格
        /// </summary>
        public Nullable<decimal> PriceSpecial { get; set; }
        /// <summary>
        /// 天数
        /// </summary>
        public string DayValue { get; set; }
    }
    public class ViewImgUrl
    {
        public string ImgUrl { get; set; }
    }

    public class ViewPackage
    {
        /// <summary>
        /// 店铺套餐表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 套餐名
        /// </summary>
        public string Title { get; set; }

        public decimal Price { get; set; }


        public List<ViewImgUrl> ImgUrlList { get; set; }

        public List<ViewPackageFood> PackageFoodList { get; set; }

        public string listimgurl { get; set; }

        public string Introduction { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        /// <summary>
        /// 菜品类型ID
        /// </summary>
        public string FoodTypeID { get; set; }
        /// <summary>
        /// 是否自助 0否 1是
        /// </summary>
        public bool IsSelfHelp { get; set; }
        /// <summary>
        /// 使用次数（计次卡专用）
        /// </summary>
        public int UsageCount { get; set; }
    }

    public class ViewPackageFood
    {
        public string FoodId { get; set; }

        public string FoodName { get; set; }
        public string FoodTypeID { get; set; }
        public string FoodTypeName { get; set; }

        public string FoodSpecificationsID { get; set; }

        public string FoodSpecificationsName { get; set; }
        public string FoodUnitName { get; set; }
        public decimal PriceGeneral { get; set; }

        public int FoodCount { get; set; }

        public decimal TotalCount { get; set; }
    }
}
