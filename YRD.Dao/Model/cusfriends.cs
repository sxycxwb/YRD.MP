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
    
    public partial class cusfriends
    {
        /// <summary>
        /// 用户好友表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 好友用户ID
        /// </summary>
        public string FriendUserID { get; set; }
        /// <summary>
        /// 好友备注名称
        /// </summary>
        public string FriendRemarkName { get; set; }
    }
}


