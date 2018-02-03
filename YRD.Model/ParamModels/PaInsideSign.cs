using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 领料签名
    /// </summary>
    public class PaInsideSign : PaIDImgByte
    {
        /// <summary>
        /// 实际领料人ID
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 入库库房ID
        /// </summary>
        public string ToWarehouseID { get; set; }
        /// <summary>
        /// 出库库房ID
        /// </summary>
        public string FromWarehouseID { get; set; }
    }
    /// <summary>
    /// 领料签名
    /// </summary>
    public class PaInsideSignBase64 : PaIDImgBase64
    {
        /// <summary>
        /// 实际领料人ID
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 入库库房ID
        /// </summary>
        public string ToWarehouseID { get; set; }
        /// <summary>
        /// 出库库房ID
        /// </summary>
        public string FromWarehouseID { get; set; }
    }
}
