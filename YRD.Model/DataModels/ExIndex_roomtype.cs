using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 主页分类
    /// </summary>
    public class ExIndex_roomtype
    {
        /// <summary>
        /// 店铺房间类型表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
            /// <summary>
            /// 标题
            /// </summary>
        public string Title { get; set; }
    }
}
