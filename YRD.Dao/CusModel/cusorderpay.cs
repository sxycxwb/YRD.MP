//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class cusorderpay
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string PayUserID { get; set; }
        public string ShopID { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<System.DateTime> PayFinishTime { get; set; }
        public Nullable<int> PayState { get; set; }
        public string Introduction { get; set; }
        public Nullable<decimal> PayPrice { get; set; }
        public Nullable<decimal> DiscountPrice { get; set; }
        public string CouponMealBackID { get; set; }
        public Nullable<decimal> CouponMealBackPrice { get; set; }
        public string CouponExtensionID { get; set; }
        public Nullable<decimal> CouponExtensionPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> UserMoney { get; set; }
        public Nullable<decimal> SmallDiscount { get; set; }
        public Nullable<int> PaySource { get; set; }
        public string DiscountStr { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string SellerID { get; set; }
        public string LinkMan { get; set; }
        public string LinkPhone { get; set; }
    }
}