﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class sysareabusiness
    {
        /// <summary>
        /// 商圈ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 省编码
        /// </summary>
        public string ProvinceId { get; set; }
        /// <summary>
        /// 市编码
        /// </summary>
        public string CityId { get; set; }
        /// <summary>
        /// 区县编码
        /// </summary>
        public string CountyId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 是否热门（1是0否）
        /// </summary>
        public int IsHot { get; set; }
        /// <summary>
        /// 首字母
        /// </summary>
        public string FirstLetter { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        public string Jianpin { get; set; }
    }
}


