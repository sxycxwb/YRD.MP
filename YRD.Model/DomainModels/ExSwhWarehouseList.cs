using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 商家仓库简易数据列表
    /// </summary>
    public class ExSwhWarehouseList
    {
        /// <summary>
        /// 商家仓库表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Title { get; set; }
    }
}
