using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// ID
    /// </summary>
    public class PaOrderStorage : PaBase
    {
        /// <summary>
        /// 主表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 库房ID
        /// </summary>
        public string WarehourseID { get; set; }
        /// <summary>
        /// 0整单入库 1 分单
        /// </summary>
        public int TakeinWarehouseType { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 分单ID
        /// </summary>
        //public string ChildOrderID { get; set; }
        /// <summary>
        /// 0 现金 1欠款
        /// </summary>
        public int PayState { get; set; }
    }
}
