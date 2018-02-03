using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 未完成的盘点明细数据列表
    /// </summary>
    public class ExSwhcheckList
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 多少种类
        /// </summary>
        public string CountType { get; set; }
        /// <summary>
        /// 库区名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 盘点状态(1盘点中 4 盘点完成)
        /// </summary>
        public string OrderState { get; set; }
        /// <summary>
        /// 盘点提交人
        /// </summary>
        public string ApplySellerName { get; set; }
    }
}
