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

    public partial class selmanager
    {
        /// <summary>
        /// 商家管理员ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 是否删除状态(1是0否)
        /// </summary>
        public Nullable<int> IsDel { get; set; }
        /// <summary>
        /// 是否锁定状态（1是0否）
        /// </summary>
        public Nullable<int> IsLock { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string ManagerNo { get; set; }
        /// <summary>
        /// 是否店铺拥有者
        /// </summary>
        public int IsOwner { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Phone { get; set; }

    }
}


