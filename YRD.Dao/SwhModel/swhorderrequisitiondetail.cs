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
    
    public partial class swhorderrequisitiondetail
    {
        /// <summary>
        /// 仓库调拨申请表详情ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 采购申请表ID
        /// </summary>
        public string OrderApplyID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 预算金额
        /// </summary>
        public Nullable<decimal> PriceBudget { get; set; }
        /// <summary>
        /// 实际金额
        /// </summary>
        public Nullable<decimal> PriceReal { get; set; }
        /// <summary>
        /// 小计预算金额
        /// </summary>
        public Nullable<decimal> TotalPriceBudget { get; set; }
        /// <summary>
        /// 小计实际金额
        /// </summary>
        public Nullable<decimal> TotalPriceReal { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 接收店铺ID
        /// </summary>
        public string ToShopID { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 材料类型名称
        /// </summary>
        public string MaterialTypeName { get; set; }
        /// <summary>
        /// 材料规格名称
        /// </summary>
        public string MaterialSpecName { get; set; }
        /// <summary>
        /// 材料品牌名称
        /// </summary>
        public string MaterialBrandName { get; set; }
        /// <summary>
        /// 计量单位编号
        /// </summary>
        public string MaterialUnitID { get; set; }
        /// <summary>
        /// 计量单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 主计量单位编号
        /// </summary>
        public string MaterialMainUnitID { get; set; }
        /// <summary>
        /// 主计量单位名称
        /// </summary>
        public string MaterialMainUnitName { get; set; }
        /// <summary>
        /// 预算数量
        /// </summary>
        public decimal CountBudget { get; set; }
        /// <summary>
        /// 预算数量(主计量单位)
        /// </summary>
        public decimal CountMainBudget { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 实际数量(主计量单位)
        /// </summary>
        public decimal CountMainReal { get; set; }
        /// <summary>
        /// 计量单位换算比例
        /// </summary>
        public decimal UnitScale { get; set; }
    }
}


