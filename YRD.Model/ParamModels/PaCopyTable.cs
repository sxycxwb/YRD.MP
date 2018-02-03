using System.Collections.ObjectModel;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 复制餐桌
    /// </summary>
    public class PaCopyTable:PaBase
    {
        /// <summary>
        /// 被复制的餐桌
        /// </summary>
        public ExIndex_table Table
        { get; set; }
        /// <summary>
        /// 选中的餐桌
        /// </summary>
        public ObservableCollection<ExIndex_table> Tables { get; set; }
        /// <summary>
        /// 对应菜单详情
        /// </summary>
        public ObservableCollection<Ex_cusorderdetail> Cusorderdetails { get; set; }
    }
}