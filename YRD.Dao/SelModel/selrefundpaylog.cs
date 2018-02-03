using System;

namespace YRD.Dao
{
    /// <summary>
    /// 反结账记录表
    /// </summary>
    public class selrefundpaylog
    {
        /// <summary>
        /// 反结账记录表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 用户订单ID（cusorder表）
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundPrice { get; set; }
        /// <summary>
        /// 订单完成时间也就是结账时间
        /// </summary>
        public DateTime OrderFinishTime { get; set; }
        /// <summary>
        /// 反结账时间
        /// </summary>
        public DateTime RefundTime { get; set; }
        /// <summary>
        /// 支付方式 支付宝 微信等 按数据库表走
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 退款方式 支付宝 微信等 按数据库表走
        /// </summary>
        public int RefundType { get; set; }
        /// <summary>
        /// 收银员ID
        /// </summary>
        public string SelManagerID { get; set; }
        /// <summary>
        /// 收银员名字
        /// </summary>
        public string SelManagerName { get; set; }
        /// <summary>
        /// 退款接收人名字
        /// </summary>
        public string PaymentPeople { get; set; }
        /// <summary>
        /// 退款接收人手机号
        /// </summary>
        public string PaymentPhone { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 餐桌ID
        /// </summary>
        public string TableID { get; set; }
    }
}