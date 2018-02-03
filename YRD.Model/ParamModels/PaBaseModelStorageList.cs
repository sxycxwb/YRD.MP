using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 采购入库申请简易数据列表
    /// </summary>
    public class PaBaseModelStorageList: PaBase
    {
        /// <summary>
        /// 仓库采购详情表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderID { get; set; }
        /// <summary>
        /// 分单ID
        /// </summary>
        public string OrderStorageID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 入库单价
        /// </summary>
        public decimal PriceReal { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        public string MaterialUnitID { get; set; }

    }
}
