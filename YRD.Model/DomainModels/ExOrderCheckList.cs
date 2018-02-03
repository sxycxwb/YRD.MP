using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 显示盘点列表
    /// </summary>
    public class ExOrderCheckList
    {
        /// <summary>
        /// 盘点单ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 盘点日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 盘点库房
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 提交人
        /// </summary>
        public string ApplySellerName { get; set; } 
        /// <summary>
        /// 盘点人
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 盘点状态
        /// </summary>
        public int OrderState { get; set; }
    }
}
