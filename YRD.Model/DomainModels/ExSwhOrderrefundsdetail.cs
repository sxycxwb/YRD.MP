using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 退货申请详情简易数据列表
    /// </summary>
    public class ExSwhOrderrefundsdetail
    {
        /// <summary>
        /// 退货申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 预算金额
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 供应商类别
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 退款结算 0现金 1 欠款
        /// </summary>
        public int PayState { get; set; }
    }

    /// <summary>
    /// 退货申请详情简易数据列表
    /// </summary>
    public class ExRefundsdetail1
    {
        /// <summary>
        /// 详情ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 退货申请表ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 退货单价
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public decimal Number { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public decimal? Total { get; set; }
    }
    /// <summary>
    /// 退货申请详情简易数据列表
    /// </summary>
    public class ExRefundsdetail2 : ExRefundsdetail1
    {
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StockCount { get; set; }
        /// <summary>
        /// 最近供货单价
        /// </summary>
        public decimal LastPrice { get; set; }
        /// <summary>
        /// 核准单价
        /// </summary>
        public decimal? RealPrice { get; set; }
        /// <summary>
        /// 核准数量
        /// </summary>
        public decimal RealCount { get; set; }
    }
    /// <summary>
    /// 提交详情审核
    /// </summary>
    public class ExRefundsdetailCheck
    {
        /// <summary>
        /// 详情 ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 退货申请表ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 核准单价
        /// </summary>
        public decimal RealPrice { get; set; }
        /// <summary>
        /// 核准数量
        /// </summary>
        public decimal RealCount { get; set; }
    }
}
