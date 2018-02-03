using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewAccountBalance
    {
        /// <summary>
        /// 店铺余额
        /// </summary>
        public string ShopMoney { get; set; }

        /// <summary>
        /// 短信条数
        /// </summary>
        public string SmsCount { get; set; }
        /// <summary>
        /// 累计充值
        /// </summary>
        public string TotalChangeMoney3 { get; set; }

        /// <summary>
        /// 累计支出
        /// </summary>
        public string TotalChangeMoney2 { get; set; }

        /// <summary>
        /// 累计收入
        /// </summary>
        public string TotalChangeMoney1 { get; set; }

        /// <summary>
        /// 累计
        /// </summary>
        public string TotalChangeCount3 { get; set; }

        /// <summary>
        /// 累计
        /// </summary>
        public string TotalChangeCount2 { get; set; }

        /// <summary>
        /// 累计
        /// </summary>
        public string TotalChangeCount1 { get; set; }
        /// <summary>
        /// 累计
        /// </summary>
        public string TotalSMSMoney { get; set; }

        /// <summary>
        /// 累计
        /// </summary>
        public string TotalSMSCount { get; set; }

        /// <summary>
        /// 累计使用次数
        /// </summary>
        public string TotalSMSUsedCount { get; set; }


    }


}
