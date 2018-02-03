using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 带id,detailid的简单模型
    /// </summary>
    public class ExIDNumber
    {
        /// <summary>
        /// 订单ID /主表id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 详情ID /详情表id
        /// </summary>
        public string DetailID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Number { get; set; }
    }
}
