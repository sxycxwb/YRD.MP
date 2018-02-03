using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.SOLib
{

    /// <summary>
    /// 登录用户
    /// </summary>
    public class SoUser
    {
        /// <summary>
        /// 用户ID编号
        /// </summary>
        public string ManagerId { get; set; }

        /// <summary>
        /// 所属店铺编号
        /// </summary>

        public string ShopId { get; set; }

        /// <summary>
        /// 店铺名
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 管理员用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 管理员用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 是否拥有者
        /// </summary>

        public int IsOwner { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime DT { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 用户登录类型
        /// </summary>
        public int UserLoginType { get; set; }

    }
}
