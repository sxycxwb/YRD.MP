using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// ID
    /// </summary>
    public class PaChildID : PaID
    {
        /// <summary>
        /// 分单ID,对应StorageID
        /// </summary>
        public string ChilID { get; set; }
    }
}
