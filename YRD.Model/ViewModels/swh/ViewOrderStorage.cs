using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{


    /// <summary>
    /// 申请入库订单进度
    /// </summary>
    public class ViewOrderStorageProgress
    {
        public string ID { get; set; }
        public string ApplySellerID { get; set; }
        public string ApplySellerName { get; set; }

        public string ApplySellerNickName { get; set; }
        public string CreateTime { get; set; }
        public string CheckTime { get; set; }
        public string CheckerID { get; set; }
        public string CheckerName { get; set; }
        public string CheckerNickName { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }

        public int PayState { get; set; }
        public string PayStateName { get; set; }
        public string CheckerImg { get; set; }
    }
    /// <summary>
    /// 采购单详情
    /// </summary>
    public class ViewOrderStorageDetail
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string MaterialSpecName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 包装单位
        /// </summary>
        public string MaterialPackUnitName { get; set; }

        /// <summary>
        /// 审核数量
        /// </summary>
        public decimal CountReal { get; set; }

        /// <summary>
        /// 审核单位
        /// </summary>
        public decimal PriceReal { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        public decimal TotalPriceReal { get; set; }
        /// <summary>
        /// 上次入库单价
        /// </summary>
        public decimal LastPrice { get; set; }

    }
}
