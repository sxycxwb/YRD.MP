using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 点餐详情
    /// </summary>
    public class PaSelSpotInfo:PaBase
    {
        /// <summary>
        /// 桌子
        /// </summary>
        public ExIndex_table Table { get; set; }
        /// <summary>
        /// 已点菜品
        /// </summary>
        public List<Ex_cusorderdetail> ListCusorderdetail { get; set; }
        /// <summary>
        /// 固定传输
        /// </summary>
       
        /// <summary>
        /// 已选菜品
        /// </summary>
        public ExSelfood selFood { get; set; }

        /// <summary>
        /// 要删除的菜预订单
        /// </summary>
        public Ex_cusorderdetail Cusorderdetail { get; set; }

    }
}
