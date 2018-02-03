namespace YRD.Model
{
    public class ExShift
    {
        /// <summary>
        /// 搅拌人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string STime { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        public string ETime { get; set; }
        /// <summary>
        /// 时间间隔
        /// </summary>
        public string tSpan { get; set; }
        /// <summary>
        /// 现金
        /// </summary>
        public string Money { get; set; }
        /// <summary>
        /// 印业收入
        /// </summary>
        public string YYMoney { get; set; }
        /// <summary>
        /// 上一般备用金
        /// </summary>
        public string LastBmoney { get; set; }
        /// <summary>
        /// 欠款收入（挂账）
        /// </summary>
        public string MoneyOwed { get; set; }
        /// <summary>
        /// 现金收入（消费收入）
        /// </summary>
        public string MoneyCash { get; set; }
        /// <summary>
        /// 售卡收入（会员开卡）
        /// </summary>
        public string MoneySellCard { get; set; }
        /// <summary>
        /// 会员卡收入
        /// </summary>
        public string MoneyCard { get; set; }
        /// <summary>
        /// 充值收入（会员充值）
        /// </summary>
        public string MoneyRechargeCard { get; set; }
        /// <summary>
        /// 预定收入（预定定金）
        /// </summary>
        public string MoneyReserve { get; set; }
        /// <summary>
        /// 备用金
        /// </summary>
        public string PettyCash { get; set; }


        /// <summary>
        /// 支付宝收入
        /// </summary>
        public string MoneyAli { get; set; }
        /// <summary>
        /// 威信收入
        /// </summary>
        public string MoneyWeiXin { get; set; }
        /// <summary>
        /// 还款收入（挂账还款）
        /// </summary>
        public string MoneyRepayment { get; set; }


        /// <summary>
        /// 上交现金
        /// </summary>
        public string PaidOnCash { get; set; }
    }
}