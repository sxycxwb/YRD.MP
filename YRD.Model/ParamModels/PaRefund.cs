using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 提交退货单审核
    /// </summary>
    public class PaRefund : PaBase
    {
        /// <summary>
        /// 仓库退货申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 申请名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 申请简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 退款结算 0现金 1 欠款
        /// </summary>
        public int PayState { get; set; } //手动添加
    }
}
