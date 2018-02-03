namespace YRD.Dao
{

    using System;

    public partial class sysshopauditlog
    {
        /// <summary>
        /// 商铺审核记录ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 商铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 审核状态 1审核通过 2审核不通过
        /// </summary>
        public int AuditStatus { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>
        public string AdminId { get; set; }
        /// <summary>
        /// 审核人昵称
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 审核原因信息
        /// </summary>
        public string AuditMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
