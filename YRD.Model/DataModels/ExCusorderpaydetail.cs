using System;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 订单支付详情
    /// </summary>
    public class ExCusorderpaydetail
    {
        /// <summary>
        /// 订单支付详情ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 支付来源（1支付宝2微信3余额4会员卡5其他）
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
        /// 成功状态（1成功2其他未成功）
        /// </summary>
        public int SuccessState { get; set; }
        /// <summary>
        /// 支付类型（1正常消费2开卡3充值卡4预定5还款6挂账）
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 挂账人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 挂账人手机
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否删除（1是0否）反结账用
        /// </summary>
        public int IsDel { get; set; }
        /// <summary>
        /// 是否启用按钮
        /// </summary>
        public bool isHD { get; set; }
    }
}