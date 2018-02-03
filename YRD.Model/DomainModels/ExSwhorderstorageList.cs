using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 采购入库申请简易数据列表
    /// </summary>
    public class ExSwhorderstorageList
    {
        /// <summary>
        /// 仓库采购申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public System.DateTime CreateDate { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 提交人姓名
        /// </summary>
        public string ApplySellerName { get; set; }
    }
}
