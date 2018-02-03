using System.Collections.Generic;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 
    /// </summary>
    public class PageExSecard
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageSum { get; set; }
        /// <summary>
        /// 商家会员卡列表
        /// </summary>
        public List<ExMyCard> MySelcards { get; set; }

        public List<ExMyCarddetail> MyCarddetails { get; set; }
        /// <summary>
        /// 商家会员卡列表
        /// </summary>
        public List<ExSelcard> ListSelcard { get; set; }
        /// <summary>
        /// 订单列表
        /// </summary>
        public List<ExOrder> ListOrder { get; set; }
    }
}