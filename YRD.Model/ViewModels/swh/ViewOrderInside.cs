using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    public class ViewOrderInside
    {

        /// <summary>
        /// 仓库内部领料申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 申请名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 出库时间
        /// </summary>
        public string InsideTime { get; set; }
        /// <summary>
        /// 出库金额
        /// </summary>
        public string InsideMoney { get; set; }
        /// <summary>
        /// 出料仓库
        /// </summary>
        public string FromWareHouseName { get; set; }
        /// <summary>
        /// 领料仓库
        /// </summary>
        public string ToWareHouseName { get; set; }
        /// <summary>
        /// 订单状态（1进行中 2已完成 3已取消）
        /// </summary>
        public int OrderState { get; set; }

        public string OrderStateName { get; set; }
        /// <summary>
        /// 实际领取操作人ID
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 实际领取操作人ID
        /// </summary>
        public string OperationSellerName { get; set; }

        public string OperationSellerNickName { get; set; }
        /// 申请表ID
        /// </summary>
        public string Introduction { get; set; }

    }

    /// <summary>
    /// 入库订单进度
    /// </summary>
    public class ViewOrderInsideProgress
    {
        public string ID { get; set; }
        public string ApplySellerID { get; set; }
        public string ApplySellerName { get; set; }
        public string ApplySellerNickName { get; set; }
        public string CreateTime { get; set; }
        public string InsideTime { get; set; }
        public string OperationSellerID { get; set; }
        public string OperationSellerName { get; set; }

        public string OperationSellerNickName { get; set; }
        public string OperationImg { get; set; }

    }
    /// <summary>
    /// 入库订单详情
    /// </summary>
    public class ViewOrderInsideDetail
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string MaterialTypeMainName { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string MaterialTypeChildName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string MaterialSpecName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>

        public decimal TotalPriceReal { get; set; }
        /// <summary>
        /// 出料仓库
        /// </summary>
        public string FromWareHouseName { get; set; }
        /// <summary>
        /// 领料仓库
        /// </summary>
        public string ToWareHouseName { get; set; }

    }

}
