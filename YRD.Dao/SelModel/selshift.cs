﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class selshift
    {
        /// <summary>
        /// 店铺收银台交班记录表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 交班人ID
        /// </summary>
        public string SellerID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public Nullable<System.DateTime> StartTime { get; set; }
        /// <summary>
        /// 时长
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public Nullable<System.DateTime> EndTime { get; set; }
        /// <summary>
        /// 总现金收入
        /// </summary>

        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 营业总收入
        /// </summary>
        public decimal TotalBusniessMoney { get; set; }
        /// <summary>
        /// 点餐收入
        /// </summary>
        public decimal MoneySpot { get; set; }
        /// <summary>
        /// 点菜单数
        /// </summary>
        public decimal CountSpot { get; set; }
 
        /// <summary>
        /// 外卖金额
        /// </summary>

        public decimal MoneyTakeout { get; set; }
        /// <summary>
        /// 外卖单数
        /// </summary>
        public int CountTakeout { get; set; }
        /// <summary>
        /// 现金收入
        /// </summary>
        public decimal MoneyCash { get; set; }
        /// <summary>
        /// 现金单数
        /// </summary>
        public int CountCash { get; set; }
        /// <summary>
        /// 银行卡收入
        /// </summary>
        public decimal MoneyBankCard { get; set; }
        /// <summary>
        /// 银行卡单数
        /// </summary>
        public int CountBankCard { get; set; }
        /// <summary>
        /// 微信收入
        /// </summary>
        public Nullable<decimal> MoneyWeiXin { get; set; }
        /// <summary>
        /// 微信数量
        /// </summary>
        public int CountWeiXin { get; set; }

        /// <summary>
        /// 支付宝收入
        /// </summary>
        public decimal MoneyAli { get; set; }
        /// <summary>
        /// 支付宝数量
        /// </summary>
        public int CountAli { get; set; }
    
        /// <summary>
        /// 会员卡收入
        /// </summary>
        public decimal MoneyCard { get; set; }
        /// <summary>
        /// 会员卡单数
        /// </summary>
        public int CountCard { get; set; }
        /// <summary>
        /// 会员开卡金额
        /// </summary>
        public decimal MoneyOpenCard { get; set; }
        /// <summary>
        /// 会员开卡次数
        /// </summary>
        public int CountOpenCard { get; set; }
        /// <summary>
        /// 会员卡充值金额
        /// </summary>
        public decimal MoneCardCharge { get; set; }
        /// <summary>
        /// 会员卡充值次数
        /// </summary>
        public int CountCardCharge { get; set; }
        /// <summary>
        /// 预定餐桌（已开台）
        /// </summary>
        public decimal OpenTableReserve { get; set; }
        /// <summary>
        /// 总预定餐桌数
        /// </summary>
        public int CountTableReserve { get; set; }
        /// <summary>
        /// 预收定金
        /// </summary>
        public decimal MoneyOrderReserve { get; set; }
        /// <summary>
        /// 预定收入
        /// </summary>
        public decimal MoneyReserve { get; set; }
        /// <summary>
        /// 预定收入单数  
        /// </summary>
        public int CountReserve { get; set; }
        /// <summary>
        /// 挂账收入
        /// </summary>
        public decimal MoneyOwed { get; set; }
        /// <summary>
        /// 挂账单数
        /// </summary>
        public int CountOwed { get; set; }

        /// <summary>
        /// 还款收入
        /// </summary>
        public decimal MoneyRepayment { get; set; }
        /// <summary>
        /// 还款单数
        /// </summary>
        public int CountRepayment { get; set; }
       
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否交班0否1是
        /// </summary>
        public int IsShift { get; set; }
    }
}

