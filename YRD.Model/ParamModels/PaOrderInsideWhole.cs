using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 领料出库订单，购物车统一提交
    /// </summary>
    public class PaOrderInsideWhole : PaBase
    {
        /// <summary>
        /// 标题，不需要就不用管了
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 实际领料人ID
        /// </summary>
        public string OperationSellerID { get; set; }       
        /// <summary>
        /// 出库库房id
        /// </summary>
        public string FromWarehouseID { get; set; }
        /// <summary>
        /// 入库库房id
        /// </summary>
        public string ToWarehouseID { get; set; }
        /// <summary>
        /// 图片数据(此数据为安卓使用，bate64格式，此字段不为空时，以此为主，忽略ImgByte)
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 图片数据(ios使用，使用这个时，请不要设置Img字段)
        /// </summary>
        public byte[] ImgByte { get; set; }
        /// <summary>
        /// 图片后缀格式，比如：.png(带上前面的.)
        /// </summary>
        public string ImgType { get; set; }
        /// <summary>
        /// 申请简介，没有就不用管了
        /// </summary>
        public string Introduction { get; set; }        
        /// <summary>
        /// 详情
        /// </summary>
        public List<OrderInsideWholeDetail> Detail { get; set; }
    }
    /// <summary>
    /// 领料出库订单，购物车统一提交--详情
    /// </summary>
    public class OrderInsideWholeDetail
    {
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Number { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        public string UnitID { get; set; }

    }
}
