using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewMessageSet
    {
        public string ShopID { get; set; }
        /// <summary>
        /// 短信生日接受
        /// </summary>
        public int SmsBirthdayAccept { get; set; }
        /// <summary>
        /// 天
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// 小时
        /// </summary>
        public int Hour { get; set; }
        /// <summary>
        /// 分钟
        /// </summary>
        public int Minute { get; set; }
        /// <summary>
        /// 短信商家接受
        /// </summary>
        public int SmsShopAccept { get; set; }
        /// <summary>
        /// 短信用户接受
        /// </summary>
        public int SmsUserAccept { get; set; }
    }
}
