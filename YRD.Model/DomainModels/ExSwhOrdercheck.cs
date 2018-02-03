using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 盘点对象
    /// </summary>
    public class ExSwhOrdercheck :PageListWithPaging<ExSwhmaterialPrice>
    {
        /// <summary>
        /// 主表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 盘点表ID
        /// </summary>
        public string OrderApplyID { get; set; }
        /// <summary>
        /// 仓库名
        /// </summary>
        public string WareHouseName { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string MaterialTypeName { get; set; }
        /// <summary>
        /// 类别ID
        /// </summary>
        public string MaterialTypeID { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal PriceReal { get; set; }
    }
}
