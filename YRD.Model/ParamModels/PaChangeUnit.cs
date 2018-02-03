using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 单位换算
    /// </summary>
    public class PaChangeUnit : PaBase
    { 
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 新的单位ID
        /// </summary>
        public string MaterialUnitID { get; set; }  


    }
}
