using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 商家仓库材料数据列表
    /// </summary>
    public class ExSwhMList
    {
        /// <summary>
        /// 仓库材料ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string  ShopID { get; set; }
        /// <summary>
        /// 材料分类父ID
        /// </summary>
        public string ParentID { get; set; }
    }
}
