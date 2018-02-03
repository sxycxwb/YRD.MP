using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ExOrderModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 订单创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 订单受理日期
        /// </summary>
        public DateTime AcceptDate { get; set; }
        /// <summary>
        /// 订单支付日期
        /// </summary>
        public DateTime PayDate { get; set; }
        /// <summary>
        /// 订单发货日期
        /// </summary>
        public DateTime SendGoodDate { get; set; }
        /// <summary>
        /// 确认收货日期
        /// </summary>
        public DateTime RecivedGoodDate { get; set; }
        /// <summary>
        /// 取消日期
        /// </summary>
        public DateTime CancelDate { get; set; }
        /// <summary>
        /// 完成日期
        /// </summary>
        public DateTime CompleteDate { get; set; }
        /// <summary>
        /// 最后一次延迟发货操作日期
        /// </summary>
        public DateTime LastLazySendDate { get; set; }
        /// <summary>
        /// 延迟发货原因
        /// </summary>
        public string LazySendReason { get; set; }
        /// <summary>
        /// 延迟发货，延迟到此日期发货
        /// </summary>
        public DateTime LazySendNextDate { get; set; }
        /// <summary>
        /// 买家id
        /// </summary>
        public int BuyUserId { get; set; }
        /// <summary>
        /// 卖家店铺id
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 发货人id
        /// </summary>
        public int SenderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RealSenderId { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 送货方式
        /// </summary>
        public int SendType { get; set; }
        /// <summary>
        /// 物流方式
        /// </summary>
        public string LogisticsName { get; set; }
        /// <summary>
        /// 物流单号
        /// </summary>
        public int LogisticsNumber { get; set; }
        /// <summary>
        /// /
        /// </summary>
        public int ReciverProvince { get; set; }
        public int ReciverCity { get; set; }
        public int ReciverArea { get; set; }
        public string ReciverName { get; set; }

        public string ReciverAddress { get; set; }
        public string SendTimeType { get; set; }
        public string ReciverPhone { get; set; }
        public string ReciverZipcode { get; set; }
        public string Memo { get; set; }
        /// <summary>
        /// 合计需要支付金额
        /// </summary>
        public decimal AllPayMoney { get; set; }
        /// <summary>
        /// 合计需要支付积分
        /// </summary>
        public int AllPayScore { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal SendPrice { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
        public int ReturnType { get; set; }
        public string StrOrderState { get; set; }

        public int Origin { get; set; }
        public int SupplyMoneySend { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
        public int Upgrade { get; set; }
    }

    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShopId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        /// <summary>
        /// 规格id
        /// </summary>
        public int SpecId { get; set; }
        /// <summary>
        /// 购买单价
        /// </summary>
        public decimal BuySinglePrice { get; set; }
        /// <summary>
        /// 购买应付积分单价
        /// </summary>
        public int BuySingleScore { get; set; }
        /// <summary>
        /// 供货价
        /// </summary>
        public decimal SupplySinglePrice { get; set; }
        /// <summary>
        /// 推广价
        /// </summary>
        public decimal AdvPrice { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyCount { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public int ReturnCount { get; set; }
        /// <summary>
        /// 未发货数量
        /// </summary>
        public int WaitToSendCount { get; set; }
        /// <summary>
        /// 应付金额
        /// </summary>
        public decimal BuyNeedPayMoney { get; set; }
        /// <summary>
        /// 应付积分
        /// </summary>
        public int BuyNeedPayScore { get; set; }
        /// <summary>
        /// 退货返还金币
        /// </summary>
        public decimal ReturnMoney { get; set; }
        /// <summary>
        /// 退货返还积分
        /// </summary>
        public int ReturnScore { get; set; }
        public decimal ActualPayMoney { get; set; }
        /// <summary>
        /// 实际支付积分
        /// </summary>
        public int ActualPayScore { get; set; }

    }
}
