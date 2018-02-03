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
    
    public partial class cusaddress
    {
        /// <summary>
        /// 用户地址表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 省ID
        /// </summary>
        public string ProvinceID { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public string CityID { get; set; }
        /// <summary>
        /// 县区ID
        /// </summary>
        public string CountyID { get; set; }
        /// <summary>
        /// 商圈ID
        /// </summary>
        public string AreaID { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 客户全部地址（省市县地址）
        /// </summary>
        public string AllAddress { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 是否默认（1是其他否）
        /// </summary>
        public Nullable<bool> IsDefault { get; set; }
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public int UserId { get; set; }
    }
}

