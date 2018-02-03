using System;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 用户订单支付
    /// </summary>
    public class ExCusorderpay
    {
        /// <summary>
        /// 实际支付金额
        /// </summary>
        public decimal TruePrice { get; set; }
        public string ID { get; set; }
        /// <summary>
        /// 下单用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 实际支付金额
        /// </summary>
        public decimal PayPrice { get; set; }
        /// <summary>
        /// 订单支付状态(0未支付1全额支付2部分支付3全额挂账4部分挂账5免单)
        /// </summary>
        public int PayState { get; set; }
      

      
        /// <summary>
        /// 下单用户ID
        /// </summary>
        public string PayUserID { get; set; }


        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
     
      
        /// <summary>
        /// 支付完成时间
        /// </summary>
        public Nullable<System.DateTime> PayFinishTime { get; set; }
     
        /// <summary>
        /// 订单备注
        /// </summary>
        public string Introduction { get; set; }
     
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal DiscountPrice { get; set; }
        /// <summary>
        /// 餐后劵ID
        /// </summary>
        public string CouponMealBackID { get; set; }
        /// <summary>
        /// 餐后劵金额
        /// </summary>
        public decimal CouponMealBackPrice { get; set; }
        /// <summary>
        /// 推广劵ID
        /// </summary>
        public string CouponExtensionID { get; set; }
        /// <summary>
        /// 推广劵金额
        /// </summary>
        public decimal CouponExtensionPrice { get; set; }
        /// <summary>
        /// 折扣（八折就是0.80）
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 用户使用金额
        /// </summary>
        public decimal UserMoney { get; set; }
        /// <summary>
        /// 支付来源((1远程2扫码3吧台4服务员)
        /// </summary>
        public int PaySource { get; set; }
        /// <summary>
        /// 优惠字符串
        /// </summary>
        public string DiscountStr { get; set; }
        /// <summary>
        /// 收银员ID(服务员或吧台)
        /// </summary>
        public string SellerID { get; set; }
        /// <summary>
        /// 挂账人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 挂账人手机号码
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 收银员姓名
        /// </summary>
        public string SelManagerName { get; set; }
        /// <summary>
        /// 抹零
        /// </summary>
        public decimal SmallDiscount { get; set; }
        /// <summary>
        /// 1普通消费2挂单
        /// </summary>
        public int toType { get; set; }
    }
}