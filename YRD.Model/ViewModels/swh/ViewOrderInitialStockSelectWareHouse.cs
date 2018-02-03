using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    /// <summary>
    /// 材料
    /// </summary>
    public class ViewOrderInitialStockSelectWareHouse
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 库房集合
        /// </summary>
        public List<ViewSelectListItem> WareHouseList { get; set; }
    }

}
