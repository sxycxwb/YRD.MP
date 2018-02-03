using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YRD.Model.EnumModels
{
    /// <summary>
    /// 消息状态枚举
    /// </summary>
    public enum EnumMessageAuditStatus
    {
        /// <summary>
        /// 消息审核成功
        /// </summary>
        MessageAuditSuccess = 1,
        /// <summary>
        /// 消息审核失败
        /// </summary>
        MessageAuditFailure = -1,
        /// <summary>
        /// 消息发布成功
        /// </summary>
        MessageFaBuSuccess = 2,
        /// <summary>
        /// 消息提交成功
        /// </summary>
        MessageSubmitAudit = 0
    }
}
