using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 namespace YRD.SO.Models
{
    public class UsersModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 判断用户级别小于等于2是用户，>2是网商
        /// </summary>
        public int? Shoplevel { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImgPath { get; set; }

        /// <summary>
        /// 子账号id
        /// </summary>
        public int SubAccountId { get; set; }

        /// <summary>
        /// 子账户名称
        /// </summary>
        public string SubAccountUsername { get; set; }

        /// <summary>
        /// 子账户角色id
        /// </summary>
        public int SubAccountRoleId { get; set; }

        /// <summary>
        /// 是否是子账号（true 是，false不是）
        /// </summary>
        public bool IsSubAccount { get; set; }

    }
}