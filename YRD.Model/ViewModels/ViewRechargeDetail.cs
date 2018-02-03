using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewRechargeDetail : ViewBase
    {

        /// <summary>
        /// 累计充值 短信充值+返俑充值
        /// </summary>
        public string TotalChangeMoney { get; set; }

        /// <summary>
        /// 返俑充值
        /// </summary>
        public string TotalChangeMoney3 { get; set; }

        /// <summary>
        /// 短信充值
        /// </summary>
        public string TotalSMSMoney { get; set; }
    }
}
