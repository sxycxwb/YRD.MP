using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 供应商分类简易数据列表
    /// </summary>
    public class ExSwhswhsupplierList
    {
        /// <summary>
        /// 供应商分类ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 供应商类别名称
        /// </summary>
        public string MaterialTitle { get; set; }
        /// <summary>
        /// 欠款金额
        /// </summary>
        public decimal Money { get; set; }
    }
}
