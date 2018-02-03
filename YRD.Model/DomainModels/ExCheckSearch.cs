using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 盘点统计
    /// </summary>
    public class ExCheckSearchTotal
    {
        /// <summary>
        /// 盘盈种类
        /// </summary>
        public decimal YingCount { get; set; }
        /// <summary>
        /// 盘盈金额 
        /// </summary>
        public decimal YingMoney { get; set; }
        /// <summary>
        /// 盘亏种类
        /// </summary>
        public decimal KuiCount { get; set; }
        /// <summary>
        /// 盘亏金额
        /// </summary>
        public decimal KuiMoney { get; set; }
    }
    /// <summary>
    /// 退货 列表
    /// </summary>
    public class ExCheckSearchList
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 盘点前总数
        /// </summary>
        public decimal CountBefore { get; set; }
        /// <summary>
        /// 盘点后总数
        /// </summary>
        public decimal CountAfter { get; set; }
        /// <summary>
        /// 盘亏数量
        /// </summary>
        public decimal CountKui { get; set; }
        /// <summary>
        /// 盘亏金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 1：盘盈 0：正常 -1：盘亏
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 详情列表
        /// </summary>
        public List<ExCheckDetail> Detail { get; set; }
    }
    /// <summary>
    /// 退货详情
    /// </summary>
    public class ExCheckDetail
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
        /// 库房
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 盘点人
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 盘点前总数
        /// </summary>
        public decimal CountBefore { get; set; }
        /// <summary>
        /// 盘点后总数
        /// </summary>
        public decimal CountAfter { get; set; }
        /// <summary>
        /// 盘亏数量
        /// </summary>
        public decimal CountKui { get; set; }
        /// <summary>
        /// 盘亏金额
        /// </summary>
        public decimal Money { get; set; }
    }
}
