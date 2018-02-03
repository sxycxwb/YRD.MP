using System;

namespace YRD.Model.DataModels
{
    public class ExMyCarddetail
    {
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayTitle { get; set; }
        /// <summary>
        /// 变化金额
        /// </summary>
        public decimal DataOriginAmount { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 卡号
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
        /// 姓名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 开卡金额
        /// </summary>
        public decimal StandAmount { get; set; }
        /// <summary>
        /// 开卡时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 余额1/次数
        /// </summary>
        public decimal AfterOriginAmount { get; set; }

        public decimal Zhekou { get; set; }
        public decimal Ymoney { get; set; }
        public decimal SMoney { get; set; }
    }
}