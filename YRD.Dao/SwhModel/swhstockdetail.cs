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
    
    public partial class swhstockdetail
    {
        /// <summary>
        /// 仓库库存变化表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 变化类型（11采购入库12调拨入库13领料入库14领料出库21退货出库22调拨出库31损耗32自动核减41盘盈入库42盘亏出库）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 变化前数量
        /// </summary>
        public decimal Before { get; set; }
        /// <summary>
        /// -1 0 1
        /// </summary>
        public int Sign { get; set; }
        /// <summary>
        /// 变化的数量（无符号）
        /// </summary>
        public decimal Data { get; set; }
        /// <summary>
        /// 变化后的数量
        /// </summary>
        public decimal After { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public System.DateTime DT { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        ///// <summary>
        ///// 材料类型名称
        ///// </summary>
        //public string MaterialTypeName { get; set; }
        /// <summary>
        /// 材料类型名称大类
        /// </summary>
        public string MaterialTypeMainName { get; set; }
        /// <summary>
        /// 材料类型名称小类
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
        /// 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BatchId { get; set; }
    }
}


