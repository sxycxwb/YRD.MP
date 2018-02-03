using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 采购订单，购物车统一提交
    /// </summary>
    public class PaOrderApplyShopCart:PaBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? Time { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public List<OrderApplyShopCartDetail> Detail { get; set; }
    }
    /// <summary>
    /// 采购订单，购物车统一提交--详情
    /// </summary>
    public class OrderApplyShopCartDetail
    {  
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Number { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        public string UnitID { get; set; }
    }
}
