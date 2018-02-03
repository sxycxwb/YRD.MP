using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 会员卡规则表（商家定义）
    /// </summary>
    public class ExSelcardrule
    {
        /// <summary>
        /// 会员卡规则ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 会员卡规则名称
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// 类型Id
        /// </summary>
        public string TypeId { get; set; }
        /// <summary>
        /// 标准价格
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
    }
}
