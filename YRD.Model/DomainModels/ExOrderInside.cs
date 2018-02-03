using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 领料申请表
    /// </summary>
    public class ExOrderInside
    {
        /// <summary>
        /// 仓库内部领料申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        //public string ShopID { get; set; }
        /// <summary>
        /// 申请名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 申请人名字
        /// </summary>
        public string ApplySellerName { get; set; }
        /// <summary>
        /// 申请人角色
        /// </summary>
        public string ApplySellerRole { get; set; }
        /// <summary>
        /// 申请简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 订单状态（1完成）
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        //public System.DateTime ApproveTime { get; set; }
        /// <summary>
        /// 实际领取操作人ID
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 实际领取操作人名字
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 实际领取操作人角色
        /// </summary>
        public string OperationSellerRole { get; set; }
        /// <summary>
        /// 领取操作时间
        /// </summary>
        public Nullable<System.DateTime> OperationTime { get; set; }
        /// <summary>
        /// 领取人签字图片
        /// </summary>
        public string OperationImg { get; set; }
        /// <summary>
        /// 领出库房
        /// </summary>
        public string FromWarehouseID { get; set; }
        /// <summary>
        /// 领出库房名称
        /// </summary>
        public string FromWarehouseName { get; set; }
        /// <summary>
        /// 入库库房
        /// </summary>
        public string ToWarehouseID { get; set; }
        /// <summary>
        /// 入库库房名称
        /// </summary>
        public string ToWarehousName { get; set; }

    }
}
