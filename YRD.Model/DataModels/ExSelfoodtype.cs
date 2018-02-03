using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 商家菜品
    /// </summary>
   public class ExSelfoodtype
    {
        /// <summary>
        /// 打印机编号
        /// </summary>
        public string PrintID { get; set; }

        /// <summary>
        /// 店铺菜品分类表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 分类名
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 是否是套餐（1是0否）
        /// </summary>
        public int State { get; set; }
    }
}
