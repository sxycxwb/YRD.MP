using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    /// <summary>
    /// 会员卡规则
    /// </summary>
    public class ViewAddCardRule
    {
        /// <summary>
        /// 会员卡规则ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 会员卡规则名称
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// 会员卡类型ID
        /// </summary>
        public string CardTypeID { get; set; } 
        /// <summary>
        /// 卡的标准价格
        /// </summary>
        public decimal StandAmount { get; set; }
        /// <summary>
        /// 购买卡时获取到的初始金额、次数
        /// </summary>
        public decimal OriginAmount { get; set; }
        /// <summary>
        /// 购买卡时获取到的额外金额、次数、打折（0.95）
        /// </summary>
        public decimal ExtentAmount { get; set; }
        /// <summary>
        /// 1启用 0停用
        /// </summary>
        public bool IsAvailable { get; set; }


    }

}
