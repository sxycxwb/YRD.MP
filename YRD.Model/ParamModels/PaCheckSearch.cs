using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 盘点搜索条件（库房id,大类，小类）
    /// </summary>
    public class PaCheckSearch : PaBase
    {
        /// <summary>
        /// 库房id
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// 材料大类id
        /// </summary>
        public string TypeID1 { get; set; }
        /// <summary>
        /// 材料小类id
        /// </summary>
        public string TypeID2 { get; set; }
    }
    /// <summary>
    /// 盘点搜索条件（库房id,大类，小类），并带附加条件，比如选择的某些材料列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaCheckSearch<T> : PaCheckSearch where T : new()
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> List { get; set; }
         
    }
}
