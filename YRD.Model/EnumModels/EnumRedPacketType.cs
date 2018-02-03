using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YRD.Model.EnumModels
{
    public enum EnumRedPacketType
    {
        /// <summary>
        /// 随机红包
        /// </summary>
        [Description("随机红包")]
        Random = 1,
        /// <summary>
        /// 平均红包
        /// </summary>
        [Description("平均红包")]
        Average = 2
    }
}
