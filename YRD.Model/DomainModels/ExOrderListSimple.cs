using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 订单简单模型（用于订单列表显示）
    /// </summary>
    public class ExOrderListSimple
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string ID { get; set; }
        ///// <summary>
        ///// 所属店铺ID
        ///// </summary>
        //public string ShopID { get; set; }
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
        ///// <summary>
        ///// 预算金额
        ///// </summary>
        //public decimal PriceBudget { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 订单状态（1审批中2审批不通过3审批通过采购中4完成）
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 提交库房
        /// </summary>
        public string Warehouse { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string ApplySellerName { get; set; }
        /// <summary>
        /// 下单人ID
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 下单人角色
        /// </summary>
        public string ApplySellerRole { get; set; }
        /// <summary>
        /// 已审核数
        /// </summary>
        public int? CheckedCount { get; set; }
    }
}
