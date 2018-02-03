using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 采购订单
    /// </summary>
    public class ExOrderApplyView
    {
        /// <summary>
        /// 仓库采购申请表ID
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
        public System.DateTime CreateDate { get; set; }
        /// <summary>
        /// 预算金额
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 申请简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 订单状态（1审批中2审批不通过3审批通过采购中4完成）
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 结账方式
        /// </summary>
        public string PayState { get; set; }
        /// <summary>
        /// 供货时间
        /// </summary>
        public Nullable<System.DateTime> NeedTime { get; set; }
        /// <summary>
        /// 提交库房
        /// </summary>
        public string Warehouse { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string ApplySellerName { get; set; }
        /// <summary>
        /// 下单人角色
        /// </summary>
        public string ApplySellerRole { get; set; }
        /// <summary>
        /// 是否审核通过
        /// </summary>
        public bool IsChecked { get; set; }
        /// <summary>
        /// 审核人id
        /// </summary>
        public string ApproveSellerID { get; set; }
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string ApproveSellerName { get; set; }
        /// <summary>
        /// 审核人角色
        /// </summary>
        public string ApproveSellerRole { get; set; }
        /// <summary>
        /// 审核内容
        /// </summary>
        public string ApproveContents { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ApproveTime { get; set; }
        /// <summary>
        /// 已审核数
        /// </summary>
        public int? CheckedCount { get; set; }
        /// <summary>
        /// 是否分单
        /// </summary>
        public bool? IsFen { get; set; }
        /// <summary>
        /// 入库表 主表ID
        /// </summary>
        public string StorageID { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 供应商类别
        /// </summary>
        public string SupplierTypeName { get; set; }
    }
    /// <summary>
    /// 列表显示的订单信息
    /// </summary>
    public class ExOrderList
    {
        /// <summary>
        /// 订单ID 
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 入库表 主表ID
        /// </summary>
        public string StorageID { get; set; }
        /// <summary>
        /// 申请名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? CreateTime { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public System.DateTime? CreateDate { get; set; }
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 订单状态（1审批中2审批不通过3审批通过采购中4整单完成 5分单 未完成 6分单完成 10整体完成[全部签名后]）
        /// </summary>
        public int? OrderState { get; set; }
        /// <summary>
        /// 已审核数
        /// </summary>
        public int? CheckedCount { get; set; }
        /// <summary>
        /// 是否分单
        /// </summary>
        public bool? IsFen { get; set; }
    }
    /// <summary>
    /// 首页列表显示的订单信息
    /// </summary>
    public class ExIndexOrderList
    {
        /// <summary>
        /// 订单ID 
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 申请名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public System.DateTime? CreateDate { get; set; }
        /// <summary>
        /// 实际金额/入库金额
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 预算金额
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 订单状态（1审批中2审批不通过3审批通过采购中4整单完成 5分单 未完成 6分单完成 10整体完成[全部签名后]）
        /// </summary>
        public int? OrderState { get; set; }
    }
}
