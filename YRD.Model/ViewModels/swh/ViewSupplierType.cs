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
    public class ViewSupplierType
    {
        /// <summary>
        /// 供应商分类表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }

    }

}
