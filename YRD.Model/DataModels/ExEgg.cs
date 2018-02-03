using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExEgg : Base
    {
        /// <summary>
        /// 消耗价格
        /// </summary>
        public decimal Consume { get; set; }
        /// <summary>
        /// 收入价格
        /// </summary>
        public decimal Income { get; set; }
    }
}
