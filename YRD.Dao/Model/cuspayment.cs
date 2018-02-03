using System;

namespace YRD.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class cuspayment
    {
    
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string PayUserID { get; set; }
        public string ShopID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PayFinishTime { get; set; }
        /// <summary>
        /// 订单支付状态(1全额支付2部分支付3全额挂账4部分挂账5免单)
        /// </summary>
        public int PayState { get; set; }
        public string Introduction { get; set; }
        public decimal PayPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string CouponMealBackID { get; set; }
        public decimal CouponMealBackPrice { get; set; }
        public string CouponExtensionID { get; set; }
        public decimal CouponExtensionPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal UserMoney { get; set; }
        public decimal SmallDiscount { get; set; }
        public int PaySource { get; set; }
        public string DiscountStr { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime CreateDate { get; set; }
        public string SellerID { get; set; }
        public string LinkMan { get; set; }
        public string LinkPhone { get; set; }


    }
}