using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 采购入库数据列表
    /// </summary>
    public class ExSwhOrderstorage
    {
        /// <summary>
        /// 入库主表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 库区ID
        /// </summary>
        public string WarehourseID { get; set; }
        /// <summary>
        /// 入库总额
        /// </summary>
        public decimal SumAmount { get; set; }
        /// <summary>
        /// 供应商类别ID
        /// </summary>
        public string SupplierTypeID { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 0 现金 1欠款
        /// </summary>
        public Nullable<int> PayState { get; set; }
        /// <summary>
        /// 欠款
        /// </summary>
        public decimal Arrears { get; set; }
        /// <summary>
        /// 分单ID
        /// </summary>
        public string ChildID { get; set; }
    }
}
