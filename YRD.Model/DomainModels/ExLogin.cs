using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    /// <summary>
    /// 登陆返回类型
    /// </summary>
    public class ExLogin
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 是否锁定（1是0否）
        /// </summary>
        public int IsLock { get; set; }
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
        public string SelShopID { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string ManagerNo { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        public string ShopName { get; set; }

    }
}
