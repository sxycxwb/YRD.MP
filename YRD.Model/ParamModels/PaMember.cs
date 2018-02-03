using System;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 
    /// </summary>
    public class PaMember:PaBase
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string SearchTxt { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 操作类型（1绑定2消费3充值）
        ///   订单管理（1正常 2外卖 3反结账 4挂账 5免单 6清台）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 会员卡 （开卡时候用）
        /// </summary>
        public ExSelcard Card { get; set; }
        /// <summary>
        ///  操作类型（1绑定2消费3充值）[会员管理]
        /// 订单管理（1正常 2外卖 3反结账 4挂账 5免单 6清台）
        /// </summary>
        public int OpType { get; set; }
        /// <summary>
        /// 消费的金额
        /// </summary>
        public decimal ChangeMoney { get; set; }
        /// <summary>
        /// 消费的次数
        /// </summary>
        public int ChangeCount { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 支付方式。
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 餐桌(订单管理用)
        /// </summary>
        public ExIndex_table Table { get; set; }
        /// <summary>
        /// 操作（1禁用、2注销）
        /// </summary>
        public int opeartion { get; set; }

    
    }
}