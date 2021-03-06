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

    public partial class swhordercheckdetail
    {
        /// <summary>
        /// 仓库盘点申请表详情ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 盘点表ID
        /// </summary>
        public string OrderApplyID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
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
        public string MaterialTypeMainName { get; set; }
        /// <summary>
        /// 材料类型名称
        /// </summary>
        public string MaterialTypeChildName { get; set; }
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
        /// 库存数量
        /// </summary>
        public decimal CountStock { get; set; }
        /// <summary>
        /// 库存数量(主计量单位)
        /// </summary>
        public decimal CountMainStock { get; set; }
        /// <summary>
        /// 盘点数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 盘点数量(主计量单位)
        /// </summary>
        public decimal CountMainReal { get; set; }
        /// <summary>
        /// 材料主单位价格
        /// </summary>
        public decimal PriceMainReal { get; set; }
        /// <summary>
        /// 计量单位换算比例
        /// </summary>
        public decimal UnitScale { get; set; }
        /// <summary>
        /// 盈亏数量(库存数量减去盘点数量)
        /// </summary>
        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// 0 不需要校验 1 需要校验
        /// </summary>
        public bool IsNeedCheck { get; set; }

        /// <summary>
        /// 0 未校验 1校验成功 -1校验失败
        /// </summary>
        public int Status { get; set; }
    }
}


