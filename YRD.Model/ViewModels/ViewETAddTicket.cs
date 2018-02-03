using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
  public  class ViewETAddTicket
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string RuleType { get; set; }
        public string ID { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Money { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string MaxCount { get; set; }
        /// <summary>
        /// 最低消费
        /// </summary>
        public string MinConsumption{ get; set; }
        /// <summary>
        /// 优惠劵规则定义的使用期限单位"月"
        /// </summary>
        public int RuleUserTimeSpan { get; set; }
    }
}
