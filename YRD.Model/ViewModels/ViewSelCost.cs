using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewCostSet
    {
        public string ID { get; set; }
        public string Title { get; set; }

        public string Introduction { get; set; }

        public string FixedCostType { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string Parameter1 { get; set; }
    }

    public class ViewExpendCharge
    {
        public string ID { get; set; }
        public string Title { get; set; }

        public string Contents { get; set; }
        public string ExpenditureMoney { get; set; }
    }
}
