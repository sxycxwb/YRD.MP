using System;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 会员卡列表
    /// </summary>
    public class ExMyCard
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 卡id
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 规则
        /// </summary>
        public string CardRuleName { get; set; }
        /// <summary>
        /// 余额1/次数
        /// </summary>
        public decimal OriginAmount { get; set; }
        /// <summary>
        /// 余额2/折扣
        /// </summary>
        public decimal ExtendAmount { get; set; }
        /// <summary>
        /// 开卡时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 使用年限
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string CardState { get; set; }

        public string CardTypeId { get; set; }
    }
}