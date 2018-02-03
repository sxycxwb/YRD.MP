using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{   
    /// <summary>
    /// 采购入库汇总单数
    /// </summary>
    public class ExApplySearchTotal
    {
        /// <summary>
        /// 采购单数
        /// </summary>
        public int ApplyCount { get; set; }
        /// <summary>
        /// 入库单数
        /// </summary>
        public int StorageCount { get; set; }
        /// <summary>
        /// 入库总额
        /// </summary>
        public decimal Money { get; set; }
    }
    /// <summary>
    /// 入库列表
    /// </summary>
    public class ExApplySearchBase
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 材料类别
        /// </summary>
        public string  Type1{ get; set; }
        /// <summary>
        /// 材料子类
        /// </summary>
        public string  Type2{ get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string  Unit{ get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal  Count{ get; set; }
        /// <summary>
        /// 入库总额
        /// </summary>
        public decimal Money { get; set; }
       
    }
    /// <summary>
    /// 入库列表
    /// </summary>
    public class ExApplySearchList: ExApplySearchBase
    {
        /// <summary>
        /// 入库列表
        /// </summary>
        public List<ExStorageDetail> Detail { get; set; }
    }
    /// <summary>
    /// 入库详情
    /// </summary>
    public class ExStorageDetail
    {
        /// <summary>
        /// 入库订单
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
        /// 供应商
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 入库库房
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 结账方式
        /// </summary>
        public string PayMode { get; set; }
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
