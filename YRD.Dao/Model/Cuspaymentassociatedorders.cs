namespace YRD.Dao
{
    public class Cuspaymentassociatedorders
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 支付表编号
        /// </summary>
        public string PaymentID { get; set; }
    }
}