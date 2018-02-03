using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewRebaterateSet
    {

        public string ID { get; set; }
        /// <summary>
        /// 商家分销返利点数（例如百分之一填0.01）
        /// </summary>
        public float Percentage { get; set; }

        /// <summary>
        /// 是否开启分销
        /// </summary>
        public int IsDistribution { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public string Remark { get; set; }


    }
}
