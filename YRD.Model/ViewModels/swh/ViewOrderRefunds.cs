using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    public class ViewOrderRefunds
    {
        public string ID { get; set; } 
        public decimal PriceReal { get; set; }
        public string CreateTime { get; set; }
        public string ApplySellerID { get; set; }
        public string ApplySellerName { get; set; }
        public string ApplySellerNickName { get; set; }
        public string WarehouseID { get; set; }
        public string WareHouseName { get; set; }
        public string ApproveSellerID { get; set; }
        public string ApproveSellerName { get; set; }
        public string ApproveSellerNickName { get; set; }
        public string ApproveTime { get; set; }

        public string OperationTime { get; set; }

        public string OperationSellerID { get; set; }

        public string OperationSellerName { get; set; }

        public string OperationSellerNickName { get; set; }
        public int OrderState { get; set; } 
        public string OrderStateName { get; set; }
        public string Introduction { get; set; }

        public string SupplierID { get; set; }

        public string SupplierName { get; set; }

        public int PayState { get; set; }

        public string PayStateName { get; set; }

        public string Title { get; set; }


    }

    /// <summary>
    /// 退货订单进度
    /// </summary>
    public class ViewOrderRefundsProgress
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

    }
    /// <summary>
    /// 退货订单详情
    /// </summary>
    public class ViewOrderRefundsDetail
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 材料名称
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
        /// 单位
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 报损数量
        /// </summary>
        public decimal CountLoss { get; set; }

        /// <summary>
        /// 最高单价
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// 最小价格
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// 平均价
        /// </summary>
        public decimal AveragePrice { get; set; }

        /// <summary>
        /// 报损总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 库房
        /// </summary>
        public string WareHouseName { get; set; }

    }

}
