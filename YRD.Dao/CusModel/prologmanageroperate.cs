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
    
    public partial class prologmanageroperate
    {
        /// <summary>
        /// 代理管理员一般操作记录表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public string ManagerID { get; set; }
        /// <summary>
        /// 日志详情
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 操作类型（1增加2删除3修改4登陆5锁定6审核7其他）
        /// </summary>
        public Nullable<int> Type { get; set; }
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


