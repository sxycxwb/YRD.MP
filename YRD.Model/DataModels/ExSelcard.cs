using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 商家会员卡表
    /// </summary>
    public class ExSelcard
    {
        /// <summary>
        /// 到期时间
        /// </summary>
        public object outTime;

        /// <summary>
        /// 使用年限
        /// </summary>
        public int YearCount { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
    

        /// <summary>
        /// 会员卡名称
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 会员卡类型ID
        /// </summary>
        public string CardTypeId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 剩余次数
        /// </summary>
        public int MoneyCount { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopId { get; set; }

        /// <summary>
        /// 所属用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 卡片拥有人姓名
        /// </summary>
        public string CardUserName { get; set; }

        /// <summary>
        /// 卡片拥有人手机号
        /// </summary>
        public string CardUserPhone { get; set; }
        /// <summary>
        /// 会员卡规则ID
        /// </summary>
        public string CardRuleId { get; set; }

        /// <summary>
        /// 会员卡规则名称
        /// </summary>
        public string CardRuleName { get; set; }
       
        /// <summary>
        /// 开卡金额 第一次
        /// </summary>
        public decimal FirstBuyMoney { get; set; }

        /// <summary>
        /// 工作人员ID（收银员）
        /// </summary>
        public string SellerId { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int PageSum { get; set; }
        /// <summary>
        /// 会员卡类型名称
        /// </summary>
        public string CardTypeName { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 金额1(直接充值的)
        /// </summary>
        public decimal Money1 { get; set; }
        /// <summary>
        ///  充值赠送的金额
        /// </summary>
        public decimal Money2 { get; set; }
        /// <summary>
        ///  折扣
        /// </summary>
        public decimal MoneyDiscount { get; set; }
        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPassword { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 金额还是次数（显示用）
        /// </summary>
        public string MoneyOrCount { get; set; }
        /// <summary>
        /// 剩余总金额
        /// </summary>
        public decimal SumMoney { get; set; }
        /// <summary>
        /// 门面地址
        /// </summary>

        public string ShopAddress { get; set; }
        /// <summary>
        /// 累积消费金额
        /// </summary>

        public decimal TotalPayMoney { get; set; }
        /// <summary>
        /// 累积重置金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 主卡金额
        /// </summary>
        public decimal MainCardMoney { get; set; }
        /// <summary>
        /// 副卡金额
        /// </summary>
        public decimal CardMoney { get; set; }
        /// <summary>
        /// 卡上jinfen
        /// </summary>
        public decimal Integral { get; set; }

        
    }
}
