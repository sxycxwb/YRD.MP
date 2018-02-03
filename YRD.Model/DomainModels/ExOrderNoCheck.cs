using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    /// <summary>
    /// 待审核订单
    /// </summary>
    public class ExOrderNoCheck
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 操作员名字
        /// </summary>
        public string ManagerName { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
