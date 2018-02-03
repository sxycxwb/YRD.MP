using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewMessageDetail : ViewBase
    {
        /// <summary>
        /// 短信充值
        /// </summary>
        public string TotalSMSMoney { get; set; }

        /// <summary>
        /// 短信条数
        /// </summary>
        public string SmsCount { get; set; }
        /// <summary>
        /// 使用条数
        /// </summary> 
        public string UsedSmsCount { get; set; }
        /// <summary>
        /// 剩余条数
        /// </summary> 
        public string RemainderSmsCount { get; set; }


    }
}
