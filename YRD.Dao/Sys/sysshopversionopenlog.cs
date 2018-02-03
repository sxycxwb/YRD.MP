namespace YRD.Dao
{

    using System;

    public partial class sysshopversionopenlog
    {
        /// <summary>
        /// 商铺版本开通记录ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 商铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 版本ID
        /// </summary>
        public int VersionID { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>
        public string AdminId { get; set; }
        /// <summary>
        /// 审核人昵称
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 版本结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
