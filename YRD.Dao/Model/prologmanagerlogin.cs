﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class prologmanagerlogin
    {
        /// <summary>
        /// 管理员登录记录表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public string ManagerID { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public Nullable<System.DateTime> LoginTime { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 代理公司ID
        /// </summary>
        public string CompanyID { get; set; }
    }
}


