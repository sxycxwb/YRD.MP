﻿using System;

namespace YRD.Model.DomainModels
{
    public class ExSelprinter
    {
        /// <summary>
        /// 商家打印机ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 打印机名
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 打印机编号
        /// </summary>
        public string PrinterNumber { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<int> IsDel { get; set; }
        /// <summary>
        /// 创建者（商家店铺人员ID）
        /// </summary>
        public string CreateSellerID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 打印机类型（1网络打印机2云打印3USB打印）
        /// </summary>
        public string PrinterType { get; set; }
        /// <summary>
        /// 打印机纸张类型（1:58,2:88）
        /// </summary>
        public string PrinterPaperType { get; set; }
        /// <summary>
        /// 是否默认打印机（1是0否）
        /// </summary>
        public Nullable<int> IsDefault { get; set; }

        public string foodtype { get; set; }
    }
}