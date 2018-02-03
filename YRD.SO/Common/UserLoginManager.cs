using YRD.SO.Enums;
using YRD.SOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using YRD.Model;
using System.Net.Http;
using Newtonsoft.Json;
using YRD.Model.DataModels;
using YRD.Dao;
using Repository;

namespace YRD.SO.Common
{
    public class UserLoginManager
    {
        #region construct
        Manager manager;
        public UserLoginManager(Manager manager)
        {
            this.manager = manager;
        }
        #endregion

        #region 检查登录

        /// <summary>
        /// 判断用户登录角色
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="rememberPassWordFlag">记住密码标识</param>
        /// <param name="rturl">返回路径</param>
        /// <param name="ip"></param>
        /// <param name="SpecialUrl">特殊的Url 供店铺装修使用</param>
        /// <returns></returns>
        public Base CheckAndLogin(string username, string password, string ip, bool rememberPassWordFlag, out SoUser soUser)
        {
            soUser = new SoUser();

            Base b = new Base();
            ExUser ex;

            string msg = string.Empty;

            #region 用户登录
            try
            {

                using (var db = new EFContext())
                {
                    var f = db.selmanager.FirstOrDefault(x => x.IsDel == 0 && x.IsLock == 0 && x.LoginName.ToLower() == username && x.LoginPwd.ToLower() == password);
                    
                    if (f != null)
                    {
                        var shop = db.selshop.FirstOrDefault(x => x.ID == f.ShopID);
                        #region addcookie
                        SoUser sm = new SoUser();
                        sm.UserName = f.LoginName;
                        sm.NickName = f.NickName;
                        sm.ManagerId = f.ID;
                        sm.ShopId = f.ShopID;
                        sm.IsOwner = f.IsOwner;
                        sm.ShopName = shop.ShopName;
                        sm.UserLoginType = (int)UserLoginType.UserSelf;
                        sm.IP = ip;
                        bool flag = SoLogin.Login(sm);
                        #endregion

                        #region 处理登录成功结果
                        if (flag)
                        {
                            b.Code = 1;
                            b.Message = "登录成功！";
                            soUser = sm;
                            return b;
                        }
                        else
                        {
                            b.Code = 0;
                            b.Message = "登录失败！";
                            soUser = sm;
                            return b;
                        }
                        #endregion
                    }
                    else
                    {
                        b.Code = 0;
                        b.Message = "登录失败！";
                    }
                }
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "登录异常";
            }
            #endregion

            return b;
        }
        #endregion

        #region 向数据库添加日志

        /// <summary>
        /// 添加登录日志
        /// </summary>
        //private void AddLoginLog(LoginLog model)
        //{
        //    manager.LoginLogManager.Add(model);
        //}
        /// <summary>
        /// 向数据库写入登陆失败信息
        /// </summary>
        //private void AddLoginFailedLog(LoginFailedLog model)
        //{
        //    manager.LoginFailedLogManager.Add(model);
        //}
        #endregion

        #region 检查用户登录失败次数

        /// <summary>
        /// 检查一个IP登陆失败是否超过30次，超过则不允许登陆
        /// </summary>
        /// <returns>超过返回True 没超过返回False</returns>
        public bool AuthencationUser(string ip)
        {
            int iLoginFailedCount = 0;
            //var date = DateTime.Now.ToString("yyyy-MM-dd");
            //try
            //{
            //    using (var db = new jhtEntities())
            //    {
            //        iLoginFailedCount = db.LoginFailedLog.Count(a => a.ip == ip && a.date == date);
            //    }
            //}
            //catch (Exception Exc)
            //{

            //}
            return iLoginFailedCount > 30;
        }
        #endregion
    }
}