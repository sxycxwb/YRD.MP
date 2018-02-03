using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 报损单 首页
    /// </summary>
    public class ExIndexOrderLossRate
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
        /// 库房
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; } 

        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderState { get; set; }
    }
}
