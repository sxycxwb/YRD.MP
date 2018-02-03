using System;

namespace YRD.Dao
{
    public class Cuspaymentdetail
    {
        public string ID { get; set; }
        /// <summary>
        /// 所属订单支付ID
        /// </summary>
        public string OrderPayID { get; set; }
        /// <summary>
        /// 支付来源（这个按照数据表定义的走）
        /// </summary>
        public string PaySource { get; set; }
        /// <summary>
        /// 支付账号
        /// </summary>
        public string BankNumber { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayMoney { get; set; }
        /// <summary>
        /// /成功状态（1成功2其他未成功）
        /// </summary>
        public int SuccessState { get; set; }
        /// <summary>
        /// 支付类型（1正常消费2挂账还款）
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 还款人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 还款人手机
        /// </summary>
        public string LinkPhone { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// （1是0否）反结账用
        /// </summary>
        public int IsDel { get; set; }
        /// <summary>
        /// 当前状态（0、预定 1、正常 2外卖 3反结账 4挂账 5挂账还款）
        /// </summary>
        public int Stetaing { get; set; }
        /// <summary>
        /// 挂账金额
        /// </summary>
        public decimal GzMoney { get; set; }
    }
}