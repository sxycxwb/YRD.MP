using System.Collections.Generic;
using System.Collections.ObjectModel;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    public class PaTranTable:PaBase
    {
        /// <summary>
        /// 原餐桌
        /// </summary>
        public ExIndex_table Table { get; set; }
        /// <summary>
        /// 转到的餐桌
        /// </summary>
        public ExIndex_table TranTable { get; set; }
        /// <summary>
        /// 要转的菜品
        /// </summary>
        public List<Ex_cusorderdetail> Cusorderdetail { get; set; }
    }
}