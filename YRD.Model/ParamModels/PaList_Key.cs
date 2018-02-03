using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 分页输入参数
    /// </summary>
    public class PaList_Key: PaPageList
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }        
    }
    /// <summary>
    /// 首页搜索产品，带有库房ID
    /// </summary>
    public class PaList_KeyWarehouse : PaPageList
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 库房ID
        /// </summary>
        public string WarehouseID { get; set; }
    }
}
