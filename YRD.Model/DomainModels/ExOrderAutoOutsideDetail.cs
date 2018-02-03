using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 销售出库详情
    /// </summary>
    public class ExOrderAutoOutsideMore
    {
        ///// <summary>
        ///// 主键ID
        ///// </summary>
        //public string ID { get; set; }
        /// <summary>
        /// 销售成本
        /// </summary>
        public decimal? SaleMoney { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 餐桌
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        /// 开台时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 结账时间
        /// </summary>
        public DateTime? PayFinishTime { get; set; }
        /// <summary>
        /// 结账人
        /// </summary>
        public string SellerName { get; set; }
        /// <summary>
        /// 结账人角色
        /// </summary>
        public string SellerRole { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        /// 结账金额
        /// </summary>
        public decimal? Money { get; set; }
        /// <summary>
        ///销售利润
        /// </summary>
        public decimal? Profit { get; set; }
    }
}
