using System.ComponentModel;

namespace YRD.SOLib
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserLoginType
    {
        /// <summary>
        /// 未登录
        /// </summary>
        [Description("未登录")]
        None = 0,
        /// <summary>
        /// 用户自已
        /// </summary>
        [Description("用户自已")]
        UserSelf = 1,
        /// <summary>
        /// 网店装修
        /// </summary>
        [Description("网店装修")]
        ShopDecoration = 2,
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Manager = 3,

        [Description("子帐号")]
        SubAccount = 4
    }
}