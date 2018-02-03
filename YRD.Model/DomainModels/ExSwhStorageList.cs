using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 采购入库申请简易数据列表
    /// </summary>
    public class ExSwhStorageList
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
        /// 状态订单状态（1审批中2审批不通过3审批通过采购中4采购完成）
        /// </summary>
        public decimal OrderState { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 0 现金 1欠款
        /// </summary>
        public Nullable<int> PayState { get; set; }
    }
}
