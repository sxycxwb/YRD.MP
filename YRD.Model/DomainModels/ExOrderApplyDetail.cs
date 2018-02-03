﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 采购入库明细数据列表
    /// </summary>
    public class ExOrderApplyDetail
    {
        /// <summary>
        /// 申请 详情表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 采购申请表ID
        /// </summary>
        public string ApplyID { get; set; }        
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 材料id
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }
        
        /// <summary>
        /// 采购数量(预算)，提交数量
        /// </summary>
        public decimal CountBudget { get; set; }
        /// <summary>
        /// 前期入库数量
        /// </summary>
        public decimal CountStock { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 预算单价 提交单价
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 实际单价
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 单位汇算
        /// </summary>
        public decimal UnitScale { get; set; }
        
        ///// <summary>
        ///// 小计实际金额
        ///// </summary>
        //public decimal TotalPriceReal { get; set; }
        ///// <summary>
        ///// 提交人
        ///// </summary>
        //public string ApplySellerName { get; set; }
        ///// <summary>
        ///// 供货时间
        ///// </summary>
        //public DateTime NeedTime { get; set; }
        ///// <summary>
        ///// 库房
        ///// </summary>
        //public string HouseName { get; set; }
        ///// <summary>
        ///// 分单ID
        ///// </summary>
        //public string ChildID { get; set; }
    }
}
