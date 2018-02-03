using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YRD.Model.DomainModels
{
    public class UserBasicInfo : Base
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public int Sex { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public int IsAvailable { get; set; }
    }


    public class ExPrettyNum
    {
        /// <summary>
        /// ID
        /// </summary>
        [Description("ID")]
        public int ID { get; set; }
        /// <summary>
        /// 靓号
        /// </summary>
        [Description("靓号")]
        public int VipUid { get; set; }
        /// <summary>
        /// 是否已经出售   未出售0 已出售1 过期缓存期2
        /// </summary>
        [Description("是否已出售")]
        public int IsSell { get; set; }
        /// <summary>
        /// 靓号价格   按月计算
        /// </summary>
        [Description("价格")]
        public decimal Price { get; set; }
        /// <summary>
        /// 靓号级别   1精品 2旗舰 3超级
        /// </summary>
        [Description("靓号级别")]
        public int Grade { get; set; }
        /// <summary>
        /// 是否可用  
        /// </summary>
        [Description("是否可用")]
        public bool IsAvailable { get; set; }
        /// <summary>
        /// 备注 现在直接写靓号名称    如:精品靓号，旗舰靓号，超级靓号等
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }

    }


    public class ExPrettyNumModel : Base
    {
        public ExPrettyNum Entity { get; set; }
    }
}
