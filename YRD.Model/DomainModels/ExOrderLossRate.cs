﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 报损单主表
    /// </summary>
    public partial class ExOrderLossRateAll
    {
        /// <summary>
        /// 仓库损耗申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 申请名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 预算金额
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string ApplySellerName { get; set; }
        /// <summary>
        /// 申请人角色名
        /// </summary>
        public string ApplySellerRole { get; set; }
        /// <summary>
        /// 申请简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 订单状态（1审批中2审批不通过3审批通过核销中4核销完成）
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 审批人ID
        /// </summary>
        public string ApproveSellerID { get; set; }
        /// <summary>
        /// 审批人名字
        /// </summary>
        public string ApproveSellerName { get; set; }
        /// <summary>
        /// 审批人角色
        /// </summary>
        public string ApproveSellerRole { get; set; }
        /// <summary>
        /// 审批内容
        /// </summary>
        public string ApproveContents { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public Nullable<System.DateTime> ApproveTime { get; set; } 
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WareHouseName { get; set; }
    }
}
