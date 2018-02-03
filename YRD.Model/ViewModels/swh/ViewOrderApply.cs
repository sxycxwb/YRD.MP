using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{

    /// <summary>
    /// 申请入库单
    /// </summary>
    public class ViewOrderApply
    {

        /// <summary>
        /// 申请订单编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 入库订单编号
        /// </summary>
        public string OrderStorageID { get; set; }

        /// <summary>
        /// 入库方式
        /// </summary>
        public int TakeinWarehouseType { get; set; }
        /// <summary>
        /// 入库方式名称
        /// </summary>
        public string TakeinWarehouseTypeName { get; set; }

        /// <summary>
        /// 申请订单时间
        /// </summary>

        public string OrderTime { get; set; }

        /// <summary>
        /// 审核订单时间
        /// </summary>
        public string ApproveTime { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>

        public string ApproveContents { get; set; }

        /// <summary>
        /// 入库提交时间
        /// </summary>
        public string StorageCreateTime { get; set; }
        /// <summary>
        /// 入库审核时间
        /// </summary>
        public string StorageCheckTime { get; set; }

        /// <summary>
        /// 库房编号
        /// </summary>
        public string WarehourseID { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string WareHourseName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Introduction { get; set; }
    }
    /// <summary>
    /// 入库订单进度
    /// </summary>
    public class ViewOrderApplyProgress
    {
        public string ID { get; set; }
        public string ApplySellerID { get; set; }
        public string ApplySellerName { get; set; }

        public string ApplySellerNickName { get; set; }
        public string CreateTime { get; set; }
        public string ApproveTime { get; set; }
        public string ApproveSellerID { get; set; }
        public string ApproveSellerName { get; set; }

        public string ApproveSellerNickName { get; set; }
        public string ApproveContents { get; set; }

    }
    /// <summary>
    /// 入库订单详情
    /// </summary>
    public class ViewOrderApplyDetail
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MaterialTitle { get; set; }
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
        /// 包装数量
        /// </summary>
        //public decimal PackBudget { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        public decimal CountBudget { get; set; }
        /// <summary>
        /// 审核数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public decimal RemainCount { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal PriceBudget { get; set; }
        /// <summary>
        /// 审核单位
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 预算总额
        /// </summary>

        public decimal TotalPriceBudget { get; set; }
        /// <summary>
        /// 核准总额
        /// </summary>

        public decimal TotalPriceReal { get; set; }
        /// <summary>
        /// 上次入库单价
        /// </summary>
        public decimal LastPrice { get; set; }

    }
}
