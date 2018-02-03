using System;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 预定
    /// </summary>
    public class paReserve:PaBase
    {
      /// <summary>
      /// 就餐时间
      /// </summary>
        public DateTime MealTime { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 预定人数
        /// </summary>
        public int ReserveCount { get; set; }
        /// <summary>
        /// 餐桌Id
        /// </summary>
        public string TableID { get; set; }

        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 是否同意大厅餐位（0不同意1同意）
        /// </summary>
        public int IsAgreeHell { get; set; }
        /// <summary>
        /// 定金
        /// </summary>
        public decimal DepositPrice { get; set; }
        /// <summary>
        /// 支付方式（1现金2支付宝3微信4银行卡5支票6转账）
        /// </summary>
        public int PayMode { get; set; }
        /// <summary>
        /// 是否发送短信（1是0否）
        /// </summary>
        public int IsSms { get; set; }
        /// <summary>
        /// 预定来源（1电话2APP3到店）
        /// </summary>
        public int OrderSource { get; set; }

        public int Sex { get; set; }
    }
}