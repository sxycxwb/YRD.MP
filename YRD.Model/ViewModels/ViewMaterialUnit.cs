using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
    public class ViewMaterialUnit
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 计量单位类型 1主计量单位 2副计量单位
        /// </summary> 
        public int UnitType { get; set; }
        /// <summary>
        /// 辅计量单位对应主计量单位的兑换比例
        /// </summary>
        public decimal UnitScale { get; set; }
    }
}
