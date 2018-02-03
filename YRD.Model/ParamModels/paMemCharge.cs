namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 充值会员卡用
    /// </summary>
    public class paMemCharge:PaBase
    {
        /// <summary>
        /// KA Id
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 规则
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayModel { get; set; }
    }
}