using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// ID
    /// </summary>
    public class PaIDImg : PaBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Img { get; set; }
    }
    /// <summary>
    /// 签名图片
    /// </summary>
    public class PaIDImgByte : PaBase
    {
        /// <summary>
        /// 订单ID 或 分单ID，看具体使用环境
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 图片数据
        /// </summary>
        public byte[] Img { get; set; }
        /// <summary>
        /// 图片后缀格式，比如：.png(带上前面的.)
        /// </summary>
        public string ImgType { get; set; }
        ///// <summary>
        ///// 如果是分单，代表是否结束，如果是整单，这个字段不起作用
        ///// </summary>
        //public bool IsFinish { get; set; }
    }
    /// <summary>
    /// 签名图片 (安卓用)
    /// </summary>
    public class PaIDImgBase64 : PaBase
    {
        /// <summary>
        /// 采购订单ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 图片数据
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 图片后缀格式，比如：.png(带上前面的.)
        /// </summary>
        public string ImgType { get; set; }
        ///// <summary>
        ///// 如果是分单，代表是否结束，如果是整单，这个字段不起作用
        ///// </summary>
        //public bool IsFinish { get; set; }
    }
}
