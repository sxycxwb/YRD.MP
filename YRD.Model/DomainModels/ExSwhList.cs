using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 库存简易数据列表
    /// </summary>
    public class ExSwhList
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Money { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Warehouse { get; set; }
        /// <summary>
        /// 状态：1审批中2审批不通过3审批通过 4完成
        /// </summary>
        public int State { get; set; }
    }
}
