using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 退货申请简易数据列表
    /// </summary>
    public class ExRefunds1
    {
        /// <summary>
        /// 退货申请表ID
        /// </summary>
        public string ID { get; set; }         
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public System.DateTime? CreateDate { get; set; }
        /// <summary>
        /// 预算金额
        /// </summary>
        public decimal PriceBudget { get; set; } 
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 审核状态  1：审核中  2：未通过审核  3：通过审核  4 完成
        /// </summary>
        public int OrderState { get; set; }
    }
    /// <summary>
    /// 退货申请简易数据列表
    /// </summary>
    public class ExSwhOrderrefunds
    {
        /// <summary>
        /// 退货申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
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
        /// 订单状态（1审批中2审批不通过3审批通过退货中4退货完成）
        /// </summary>
        public decimal OrderState { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
    }
}
