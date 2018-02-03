using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 包括材料类别与材料列表
    /// </summary>
    public class ExTypeAndList
    {
        /// <summary>
        /// 材料类别名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 材料列表
        /// </summary>
        public List<ExMaterialSimple> MaterialList { get; set; }
    }
}
