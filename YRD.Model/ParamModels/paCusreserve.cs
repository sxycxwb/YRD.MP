using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 预定
    /// </summary>
     public class PaCusreserve:PaBase
    {
        /// <summary>
        /// 预定类
        /// </summary>
        public ExIndex_cusreserve Cusreserve { get; set; }
        /// <summary>
        /// 预定时间
        /// </summary>
        public string Mdate { get; set; }

    }
}
