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
    
    public partial class sysuserfeedback
    {
        /// <summary>
        /// 用户反馈记录表
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CteateTime { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 回复状态（1是0否）
        /// </summary>
        public Nullable<int> State { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string ManagerID { get; set; }
        /// <summary>
        /// 回复消息内容
        /// </summary>
        public string ReMessage { get; set; }
        /// <summary>
        /// 回复短信内容
        /// </summary>
        public string ReSMS { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public Nullable<System.DateTime> ReTime { get; set; }
        /// <summary>
        /// 用户登录名称
        /// </summary>
        public string UserLoginName { get; set; }
    }
}

