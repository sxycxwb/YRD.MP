using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    /// <summary>
    /// 材料
    /// </summary>
    public class ViewMaterial
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
        /// 材料类型
        /// </summary>
        public string MaterialTypeMainID { get; set; }
        /// <summary>
        /// 材料类型
        /// </summary>
        public string MaterialTypeMainName { get; set; }
        /// <summary>
        /// 材料类型
        /// </summary>
        public string MaterialTypeChildID { get; set; }
        /// <summary>
        /// 材料类型
        /// </summary>
        public string MaterialTypeChildName { get; set; }
        /// <summary>
        /// 主计量单位编号
        /// </summary>
        public string MaterialMainUnitID { get; set; }
        /// <summary>
        /// 主计量单位名称
        /// </summary>
        public string MaterialMainUnitName { get; set; }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public string MaterialBrandID { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string MaterialBrandName { get; set; }
        /// <summary>
        /// 包装单位
        /// </summary>
        public string MaterialPackageUnitID { get; set; }
        /// <summary>
        /// 包装单位
        /// </summary>
        public string MaterialPackageUnitName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PackageCount { get; set; }
        /// <summary>
        /// 库存上限
        /// </summary>
        public int MaxCount { get; set; }
        /// <summary>
        /// 库存下线
        /// </summary>
        public int MinCount { get; set; }
        /// <summary>
        /// 参考价
        /// </summary>
        public decimal ReferPrice { get; set; }
        /// <summary>
        /// 平均价
        /// </summary>
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// 上一次价格
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
        /// <summary>
        /// 数量
        /// </summary>
        public decimal CountNum { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 损耗率
        /// </summary>
        public decimal LossRate { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否可用 删除之后不可用
        /// </summary>
        public bool IsAvailable { get; set; }

    }

}
