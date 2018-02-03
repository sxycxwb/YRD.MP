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
    public class ExOrderRefunds
    {
        /// <summary>
        /// 申请表ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal PriceReal { get; set; }

        /// <summary>
        ///  审批时间时间
        /// </summary>
        public string ApproveTime { get; set; }

        /// <summary>
        /// 审批用户编号
        /// </summary>
        public string ApproveSellerID { get; set; }
        /// <summary>
        /// 审批用户名
        /// </summary>

        public string ApproveSellerName { get; set; }

        /// <summary>
        /// 负责用户编号
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 负责用户名
        /// </summary>

        public string OperationSellerName { get; set; }

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
        public int OrderState { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string ApproveContents { get; set; }
    }
}
