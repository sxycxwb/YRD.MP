using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class PaOrderInside
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
        /// 经手人
        /// </summary>

        public string OperationSellerID { get; set; }
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
