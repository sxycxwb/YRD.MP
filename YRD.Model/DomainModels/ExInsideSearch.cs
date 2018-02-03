using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 领料出库汇总单数
    /// </summary>
    public class ExInsideSearchTotal
    {
        /// <summary>
        /// 领料单数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 领取种类 
        /// </summary>
        public int TypeCount { get; set; }
        /// <summary>
        /// 领料库房
        /// </summary>
        public int OutWarehouse { get; set; }
        /// <summary>
        /// 入库库房
        /// </summary>
        public int InWarehouse { get; set; }
    }

    /// <summary>
    /// 领料 列表
    /// </summary>
    public class ExInsideSearchList : ExApplySearchBase
    {
        /// <summary>
        /// 领出库房
        /// </summary>
        public string FromWarehouse { get; set; }
        /// <summary>
        /// 调入库房
        /// </summary>
        public string ToWarehouse { get; set; }
        /// <summary>
        /// 详情列表
        /// </summary>
        public List<ExInsideDetail> Detail { get; set; }
    }
    /// <summary>
    /// 领料详情
    /// </summary>
    public class ExInsideDetail
    {
        /// <summary>
        /// 订单ID
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
        /// 领出库房
        /// </summary>
        public string FromWarehouse { get; set; }
        /// <summary>
        /// 调入库房 
        /// </summary>
        public string ToWarehouse { get; set; }
        /// <summary>
        /// 领料人
        /// </summary>
        public string ApplySellerName { get; set; }
        ///// <summary>
        ///// 结账方式
        ///// </summary>
        //public string PayMode { get; set; }
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
