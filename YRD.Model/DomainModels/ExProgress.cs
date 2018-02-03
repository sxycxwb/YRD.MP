using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 订单进度
    /// </summary>
    public class ExProgress
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 入库单ID
        /// </summary>
        public string StorageID { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string ApplySellerName { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 描述：库房名 或 签名图
        /// </summary>
        public string Remark { get; set; }
    }
}
