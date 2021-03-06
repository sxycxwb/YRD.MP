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
    
    public partial class swhwarehouse
    {
        /// <summary>
        /// 店铺仓库表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string SelManagerID { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 是否自动出库 1有 0 无
        /// </summary>
        public bool IsAuto { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否可用 删除之后不可用
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}


