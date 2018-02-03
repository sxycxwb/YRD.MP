using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 库存简易数据列表
    /// </summary>
    public class ExOrderApply
    {
        /// <summary>
        /// 仓库采购申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 分单id
        /// </summary>
        public string ChildOrderID { get; set; }
        /// <summary>
        /// 0整单入库 1 分单
        /// </summary>
        public int TakeinWarehouseType { get; set; }
        /// <summary>
        /// 0整单入库 1 分单
        /// </summary>
        public string TakeinWarehouseTypeName { get; set; }
        /// <summary>
        /// 申请订单时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        ///  审批时间时间
        /// </summary>
        public string ApproveTime { get; set; }
        /// <summary>
        /// 审核订单时间
        /// </summary>
        public string AuditTime { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public string CheckTime { get; set; }
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
        public string State { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Introduction { get; set; }
    }

    /// <summary>
    /// 库存简易数据列表
    /// </summary>
    public class ExOrderApplyModel
    {
        /// <summary>
        /// 仓库采购申请表ID
        /// </summary>
        public string ID { get; set; }
         
        /// <summary>
        /// 申请订单时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        ///  审批时间时间
        /// </summary>
        public string ApproveTime { get; set; }
        /// <summary>
        /// 审核订单时间
        /// </summary>
        public string AuditTime { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public string CheckTime { get; set; }
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
        public string State { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Introduction { get; set; }
    }
}
