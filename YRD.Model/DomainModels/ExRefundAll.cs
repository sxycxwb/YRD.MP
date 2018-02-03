using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 退货单主表 所有字段
    /// </summary>
    public class ExRefundAll
    {
        /// <summary>
        /// 仓库退货申请表ID
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
        /// 申请人名字
        /// </summary>
        public string ApplySellerName { get; set; }
        /// <summary>
        /// 申请人角色
        /// </summary>
        public string ApplySellerRole { get; set; }
        /// <summary>
        /// 申请简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 订单状态（1审批中2审批不通过3审批通过退货中4退货完成）
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
        /// 出库库管ID
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 出库库管名字
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 出库库管角色
        /// </summary>
        public string OperationSellerRole { get; set; }
        /// <summary>
        /// 出库时间
        /// </summary>
        public Nullable<System.DateTime> OperationTime { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 仓库名字
        /// </summary>
        public string WareHouseName { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }  //手动添加的
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }  
        /// <summary>
        /// 取货人姓名 提货人
        /// </summary>
        public string RefundName { get; set; }
        /// <summary>
        /// 退货供应商电话
        /// </summary>
        public string RefundPhone { get; set; }
        /// <summary>
        /// 退货供应商签字图片
        /// </summary>
        public string RefundImage { get; set; }
        /// <summary>
        /// 退款结算 0现金 1 欠款
        /// </summary>
        public string PayState { get; set; } //手动添加
        /// <summary>
        /// 添加结算单的人
        /// </summary>
        public string MoneyDetailName { get; set; }
        /// <summary>
        /// 添加结算单的人 角色
        /// </summary>
        public string MoneyDetailRole { get; set; }
        /// <summary>
        /// 结算单时间
        /// </summary>
        public DateTime? MoneyDetailTime { get; set; }
    }
}
