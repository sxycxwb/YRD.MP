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
    
    public partial class sysnoticere
    {
        /// <summary>
        /// 消息接收表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public Nullable<System.DateTime> SendTime { get; set; }
        /// <summary>
        /// 用户接收时间
        /// </summary>
        public Nullable<System.DateTime> ReTime { get; set; }
        /// <summary>
        /// 接收人ID(只有单个)ID供查看给发送给谁
        /// </summary>
        public string ReceiveUsersID { get; set; }
        /// <summary>
        /// 接收人删除状态(1.已删除.0未删除) 软删除
        /// </summary>
        public Nullable<int> IsDel { get; set; }
        /// <summary>
        /// 接收人查看状态(1.已查看.0未查看) 
        /// </summary>
        public Nullable<int> ReState { get; set; }
        /// <summary>
        /// 关联的发件箱记录ID,控制那几条数据是一起发送的
        /// </summary>
        public string SendMsgID { get; set; }
        /// <summary>
        /// 接收者用户类型 （1管理员2代理3商家4用户）
        /// </summary>
        public Nullable<int> ReUserType { get; set; }
        /// <summary>
        /// 接收者用户类型详情加用户ID 例如（1-25）
        /// </summary>
        public string ReUserTypeInfo { get; set; }
        /// <summary>
        /// 发送人名称
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 接收店铺ID
        /// </summary>
        public string ShopID { get; set; }
    }
}


