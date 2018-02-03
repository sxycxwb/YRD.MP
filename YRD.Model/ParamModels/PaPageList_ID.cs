using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 带ID的分页参数
    /// </summary>
    public class PaPageList_ID : PaPageList
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
    }
   
    /// <summary>
    /// 带两个ID的分页参数
    /// </summary>
    public class PaPageList_ID_StorageID : PaPageList_ID
    { 
        /// <summary>
        /// (分单)入库主表ID
        /// </summary>
        public string StorageID { get; set; }
    }
}
