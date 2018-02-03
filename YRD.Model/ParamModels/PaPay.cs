using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 用户订单支付
    /// </summary>
    public class PaPay:PaBase
    {
        /// <summary>
        /// 订单
        /// </summary>
        public ExCusorderpay Cusorderpay { get; set; }
        /// <summary>
        /// 订单详情
        /// </summary>
        public ExCusorderpaydetail Cusorderpaydetail { get; set; }
        /// <summary>
        /// 对应餐桌
        /// </summary>
        public List<ExIndex_table> Table { get; set; }
        /// <summary>
        /// 对应订单（还款用）
        /// </summary>
        public List<ExOrder> Orders { get; set; }
    }
}