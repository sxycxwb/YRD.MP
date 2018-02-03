using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 进销核算对比结果
    /// </summary>
    public class ExApplyAutoSideSearchTotal
    {
        ///// <summary>
        ///// 入库数量
        ///// </summary>
        //public decimal InCount { get; set; }
        ///// <summary>
        ///// 销售数量
        ///// </summary>
        //public decimal OutCount { get; set; }
         
        /// <summary>
        /// 入库总额
        /// </summary>
        public decimal InMoney { get; set; }
        /// <summary>
        /// 销售总额
        /// </summary>
        public decimal OutMoney { get; set; }
    }
    /// <summary>
    /// 进销核算对比结果详情
    /// </summary>
    public class ExApplyAutoSideDetail
    {
        /// <summary>
        /// 原料名称
        /// </summary>
        public string MaterialName { get; set; }
        ///// <summary>
        ///// 类别
        ///// </summary>
        //public string MaterialTypeName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string MaterialSpecName { get; set; }       
        ///// <summary>
        ///// 库房
        ///// </summary>
        //public string WarehouseName { get; set; }        
        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal InCount { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public decimal OutCount { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
        ///// <summary>
        ///// 单价
        ///// </summary>
        //public decimal Price { get; set; }
        /// <summary>
        /// 入库总额
        /// </summary>
        public decimal InMoney { get; set; }
        /// <summary>
        /// 销售总额
        /// </summary>
        public decimal OutMoney { get; set; }
    }
}
