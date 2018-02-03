using System;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 用户会员卡操作记录表	
    /// </summary>
    public class ExSelcardoperationuser
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        ///  操作类型（1绑定2消费3充值）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 消费的金额或者次数
        /// </summary>
        public decimal ChangeMoney { get; set; }
        /// <summary>
        /// 支付方式。主要是充值用 现金,支付宝等 
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 操作人员ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 卡ID
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 商家会员卡表
        /// </summary>
        public ExSelcard Selcard { get; set; }
        /// <summary>
        /// 规则名称
        /// </summary>
        public string CardRuleName { get; set; }

    }
}