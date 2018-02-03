using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 销售出库汇总单数
    /// </summary>
    public class ExAutoOutSideSearchTotal
    {
        /// <summary>
        /// 销售单数
        /// </summary>
        public int SaleCount { get; set; }
        /// <summary>
        /// 销售总额 
        /// </summary>
        public decimal SaleMoney { get; set; }

        /// <summary>
        /// 出库单数
        /// </summary>
        public int OutCount { get; set; }
        /// <summary>
        /// 销售总额
        /// </summary>
        public decimal OutMoney { get; set; }
    }
    /// <summary>
    /// 销售出库列表
    /// </summary>
    public class ExAutoOutSideSearchList: ExApplySearchBase
    {
        /// <summary>
        /// 详情列表
        /// </summary>
        public List<ExAutoOutSideDetail> Detail { get; set; }
    }
    /// <summary>
    /// 详情
    /// </summary>
    public class ExAutoOutSideDetail
    {
        /// <summary>
        /// 订单
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string MaterialSpecName { get; set; }        
        /// <summary>
        /// 出库库房
        /// </summary>
        public string WarehouseName { get; set; }       
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public decimal Total { get; set; }
    }
}
