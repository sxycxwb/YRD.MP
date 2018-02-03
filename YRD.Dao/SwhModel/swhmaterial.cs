﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;

    public partial class swhmaterial
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
        /// 材料类型ID
        /// </summary>
        public string MaterialTypeID { get; set; }
        /// <summary>
        /// 主计量单位编号
        /// </summary>
        public string MaterialMainUnitID { get; set; }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public string MaterialBrandID { get; set; }
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
        /// 剩余数量
        /// </summary>
        public decimal RemainCount { get; set; }
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
        /// 是否可用 删除之后不可用(1是0否)
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}


