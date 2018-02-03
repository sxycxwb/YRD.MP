using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 日志配置
    /// </summary>
    public enum LogEnabled
    {
        /// <summary>
        /// 调试日志
        /// </summary>
        IsDebugEnabled,
        /// <summary>
        /// 提示日志
        /// </summary>
        IsInfoEnabled,
        /// <summary>
        /// 警告日志
        /// </summary>
        IsWarnEnabled,
        /// <summary>
        /// 错误日志
        /// </summary>
        IsErrorEnabled,
        /// <summary>
        /// 重大日志
        /// </summary>
        IsFatalEnabled
    }

}
