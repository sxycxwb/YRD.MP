using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    public class MyEnum
    {
        /// <summary>
        /// 采购订单状态
        /// </summary>
        public enum ApplyOrderState
        {
            /// <summary>
            /// 提交 未审核
            /// </summary>
            Submit = 1,
            /// <summary>
            /// 审核 未通过
            /// </summary>
            CheckNo = 2,
            /// <summary>
            /// 审核 已通过
            /// </summary>
            CheckYes = 3,
            /// <summary>
            /// 整单入库完成
            /// </summary>
            Whole = 4,
            /// <summary>
            /// 分单入库 未完成
            /// </summary>
            PointNoFinish = 5,
            /// <summary>
            /// 分单入库完成
            /// </summary>
            PointFinish = 6,
            /// <summary>
            /// 签字 流程完成
            /// </summary>
            Sign = 10
        }
    }
}
