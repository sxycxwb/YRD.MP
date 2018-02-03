using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 显示盘点表
    /// </summary>
    public class ExOrderCheck
    {
        /// <summary>
        /// 盘点单ID
        /// </summary>
        public string ID { get; set; }        
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime? OperationTime { get; set; }        
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 盘点库房
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 盘点库房ID
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// 提交人
        /// </summary>
        public string ApplySellerName { get; set; } 
        /// <summary>
        /// 申请人id
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 盘点人
        /// </summary>
        public string OperationSellerName { get; set; }
        /// <summary>
        /// 盘点人id
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 盘点状态1提交   2盘点完成
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 备注 申请简介
        /// </summary>
        public string Introduction { get; set; }
    }
}
