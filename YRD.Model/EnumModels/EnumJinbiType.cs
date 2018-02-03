using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YRD.Model.EnumModels
{
    public enum EnumJinbiType
    {
        [Description("在线充值")]
        RechargeOnLine = 2,
        [Description("线下充值")]
        RechargeOffLine = 3,
        [Description("积分购买")]
        ScoreBuy = 5,
        [Description("发红包")]
        SendRedPacket = 31,
        [Description("收红包")]
        ReceiveRedPacket = 32,
        [Description("红包退回")]
        BackRedPacket = 33,
        [Description("购买模版")]
        BuyWebsite = 34,
        [Description("我要加盟")]
        JoinUs = 41,
        [Description("消息置顶")]
        ToTop = 51,
        [Description("置顶退回")]
        BackToTop = 52
    }
}
