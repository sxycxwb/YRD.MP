using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 入库主表显示
    /// </summary>
    public class ExOrderStorage
    {
        /// <summary>
        /// 入库主表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 采购申请表ID,订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 0整单入库 1 分单
        /// </summary>
        public int TakeinWarehouseType { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 分单id
        /// </summary>
        public string ChildOrderID { get; set; }
        /// <summary>
        /// 库房id
        /// </summary>
        public string WarehourseID { get; set; }       
        /// <summary>
        /// 0 现金 1欠款
        /// </summary>
        public int PayState { get; set; }
        /// <summary>
        /// 入库总额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 提交人
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 提交人名字
        /// </summary>
        public string ApplySellerName { get; set; }
        /// <summary>
        /// 提交人角色
        /// </summary>
        public string ApplySellerRole { get; set; }
        /// <summary>
        /// 库管审核人
        /// </summary>
        public string CheckerID { get; set; }
        /// <summary>
        /// 审核人名称
        /// </summary>
        public string CheckerName { get; set; }
        /// <summary>
        /// 审核人角色
        /// </summary>
        public string CheckerRole { get; set; }
        /// <summary>
        /// 状态 1：入库 2：审核未通过入库 4：已完成
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public Nullable<System.DateTime> CheckTime { get; set; }
      
        /// <summary>
        /// 分单次数
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        /// 分单标题
        /// </summary>
        public string Title { get; set; }
    }
}
