using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    public class ViewOrderAutoOutside
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 出库时间
        /// </summary>

        public string CreateTime { get; set; }
        /// <summary>
        /// 菜品销售
        /// </summary>
        public string PriceOrder { get; set; }

        /// <summary>
        /// 结账时间
        /// </summary>
        public string PayFinishTime { get; set; }
        /// <summary>
        /// 原料出库
        /// </summary>
        public string PriceBudget { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public string Profit { get; set; }


    }

    /// <summary>
    /// 销售出库进度
    /// </summary>
    public class ViewOrderAutoOutsideProgress
    {
        public string ID { get; set; }
        public string OrderSellerID { get; set; }
        public string OrderSellerName { get; set; }
        public string OrderTime { get; set; }
        public string OrderSource { get; set; }
        public string OrderSourceName { get; set; }
        public string ApproveTime { get; set; }
        public string ApproveSellerID { get; set; }
        public string ApproveSellerName { get; set; }
        public string ApproveContents { get; set; }

    }

    /// <summary>
    /// 材料
    /// </summary>
    public class ViewOrderAutoOutsideFood
    {

        /// <summary>
        /// 菜品数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 菜品
        /// </summary>
        public List<ViewOrderAutoOutsideFoodDetail> ViewViewOrderAutoOutsideFoodDetailList { get; set; }

        /// <summary>
        /// 进度模型
        /// </summary>
        public ViewOrderAutoOutsideProgress ViewOrderAutoOutsideProgress { get; set; }
    }

    /// <summary>
    /// 菜品 
    /// </summary>
    public class ViewOrderAutoOutsideFoodDetail
    {
        /// <summary>
        /// 仓库自动出库单详情ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 材料
        /// </summary>
        public string FoodID { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 是否套餐
        /// </summary>
        public int IsPackage { get; set; }
        /// <summary>
        /// 是否套餐名称 
        /// </summary>

        public string IsPackageName { get; set; }
        /// <summary>
        /// 套餐名称
        /// </summary>
        public string PackageName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string PackageSpecifications { get; set; }
        /// <summary>
        /// 菜品数量
        /// </summary>
        public int FoodCount { get; set; }
        /// <summary>
        /// 菜品金额
        /// </summary>
        public decimal FoodPriceBudget { get; set; }
        /// <summary>
        /// 成本合计
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 材料详情数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 材料
        /// </summary>
        public List<ViewOrderAutoOutsideMaterial> ViewOrderAutoOutsideMaterialList { get; set; }



    }

    /// <summary>
    /// 材料
    /// </summary>
    public class ViewOrderAutoOutsideMaterial
    {
        /// <summary>
        /// 材料类型 1主料2辅料
        /// </summary>
        public int MaterialPriceType { get; set; }
        /// <summary>
        /// 1主料2辅料
        /// </summary>

        public string MaterialPriceTypeName { get; set; }

        /// <summary>
        /// 材料详情数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 材料
        /// </summary>
        public List<ViewOrderAutoOutsideMaterialDetail> ViewOrderAutoOutsideMaterialDetailList { get; set; }

    }

    /// <summary>
    /// 材料详情
    /// </summary>
    public class ViewOrderAutoOutsideMaterialDetail
    {
        /// <summary>
        /// 仓库盘点申请表详情ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 材料单位
        /// </summary>
        public string MaterialUnitID { get; set; }
        /// <summary>
        /// 材料单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 材料规格
        /// </summary>
        public string MaterialSpecificationsID { get; set; }
        /// <summary>
        /// 材料规格名称
        /// </summary>
        public string MaterialSpecificationsName { get; set; }
        /// <summary>
        /// 材料数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 均价
        /// </summary>
        public decimal MateriaPrice { get; set; }

        /// <summary>
        /// 材料小计
        /// </summary>
        public decimal MaterialTotal { get; set; }

    }

}
