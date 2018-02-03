using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 领料单 首页
    /// </summary>
    public class ExIndexOrderInside
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
        /// 出库库房
        /// </summary>
        public string FromWarehouse { get; set; }
        /// <summary>
        /// 入库库房
        /// </summary>
        public string ToWarehouse { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string ApplySellerName { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderState { get; set; }
    }
}
