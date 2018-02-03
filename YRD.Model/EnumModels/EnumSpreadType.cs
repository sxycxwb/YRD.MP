using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YRD.Model.EnumModels
{
    public enum EnumSpreadType
    {
        /// <summary>
        /// 红包推广
        /// </summary>
        [Description("红包推广")]
        RedPacket = 1,
        /// <summary>
        /// 广告推广
        /// </summary>
        [Description("广告推广")]
        Advert = 2,
        /// <summary>
        /// 置顶推广
        /// </summary>
        [Description("置顶推广")]
        ToTop = 3
    }
}
