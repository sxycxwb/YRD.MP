using System;

namespace YRD.Dao
{
    /// <summary>
    /// 结账还款记录表
    /// </summary>
    public class selrepaymentlog
    {
        /// <summary>
        /// 结账还款记录表ID
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
        /// 欠款金额
        /// </summary>
        public decimal ArrearsPrice { get; set; }
        /// <summary>
        /// 已支付金额
        /// </summary>
        public decimal PaymentPrice { get; set; }
        /// <summary>
        /// 支付宝 微信等 按数据库表走
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 收银员名字
        /// </summary>
        public string SelManagerID { get; set; }
        /// <summary>
        /// 收银员名字
        /// </summary>
        public string SelManagerName { get; set; }
        /// <summary>
        /// 挂账人名字
        /// </summary>
        public string PaymentPeople { get; set; }
        /// <summary>
        /// 挂账人手机号
        /// </summary>
        public string PaymentPhone { get; set; }
        /// <summary>
        /// 状态（1挂账2还款）
        /// </summary>
        public int PayState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 订单完成时间也就是挂账时间
        /// </summary>
        public DateTime OrderFinishTime { get; set; }
        /// <summary>
        /// 还款时间
        /// </summary>
        public DateTime PayTime { get; set; }
       
    }
}