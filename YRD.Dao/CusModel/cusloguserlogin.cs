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
    
    public partial class cusloguserlogin
    {
        /// <summary>
        /// 用户登录记录表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Nullable<int> UserID { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public Nullable<System.DateTime> LoginTime { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// 设备类型（1安卓2苹果3网页4其他）
        /// </summary>
        public string EquipmentType { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}


