using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
   public class ViewActivitysaleadd
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 促销图片
        /// </summary>
        public string H5Url { get; set; }
        /// <summary>
        ///  1 活动 2 会员卡
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endTime { get; set; }
    }
}
