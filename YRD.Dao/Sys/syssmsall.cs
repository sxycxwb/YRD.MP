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
    
    public partial class syssmsall
    {
        /// <summary>
        /// 手机短信表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 接收短信手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 发送时间(可预约发送)
        /// </summary>
        public Nullable<System.DateTime> SendTime { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Contonts { get; set; }
        /// <summary>
        /// 短信类别
        /// </summary>
        public string SMSTypeID { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<int> IsDel { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 发送状态（1已发送，0未发送,2发送失败）
        /// </summary>
        public Nullable<int> SendState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 扣款条数
        /// </summary>
        public Nullable<int> CountNum { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
    }
}

