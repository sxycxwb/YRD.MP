using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Exmanager
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
    }
}
