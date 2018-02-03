using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 退货
    /// </summary>
    public class PaOrderRefunds
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 商家编号
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 库房编号
        /// </summary>

        public string WareHouseID { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>

        public string SupplierID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>

        public DateTime? StartDateTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>

        public DateTime? EndDateTime { get; set; }



    }
}
