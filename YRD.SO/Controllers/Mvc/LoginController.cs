using System.Web.Mvc;
using YRD.SO.Common;
using System;
using System.Diagnostics;
using System.Net.Http;
using YRD.SOLib;
using System.Linq;
using YRD.SO.Models;
using Newtonsoft.Json;
using log4net;
using YRD.Model.ViewModels;
using Repository; 

namespace YRD.SO.Controllers.Mvc
{

    public class LoginController : Controller
    {
        public ActionResult Index(string url)
        {
            ViewBag.UserName = string.Empty;
            ViewBag.Url = url;
            return View();
        }

        public JsonResult UserLogin()
        {
            #region field

            var iLog = log4net.LogManager.GetLogger("LogToTXT");

            //仿照sso添加登录信息模型
            ViewUserLogin model = new ViewUserLogin();
            string msg = string.Empty;
            bool flag = false;

            var userName = Request.Form["txtUserName"];
            var passWord = Request.Form["txtPassWord"];
            var vailCode = Request.Form["txtVailCode"];
            var chkFlag = Request.Form["chkReMember"];
            var url = Request.Form["url"];

            string ip = SM.Current.IPManager.GetIP();
            #endregion

            #region Login

            try
            {
                #region 验证信息
                if (string.IsNullOrEmpty(userName))
                {
                    msg = "请输入用户名";
                    flag = true;
                }
                if (string.IsNullOrEmpty(passWord))
                {
                    msg = "请输入密码";
                    flag = true;
                }
                if (string.IsNullOrEmpty(vailCode))
                {
                    msg = "请输入验证码";
                    flag = true;
                }
                if (Session["ValidateCode"] == null || vailCode != Session["ValidateCode"].ToString())
                {
                    msg = "验证码输入错误";
                    flag = true;
                }
                if (!string.IsNullOrEmpty(url))
                {
                    url = SOLib.SoLogin.Decrypt(url);
                }

                if (flag)
                {
                    ViewBag.Msg = msg;
                    ViewBag.UserName = userName;

                    model.Code = 0;
                    model.Message = msg;

                    return Json(model);
                }
                #endregion

                #region 验证IP

                if (Manager.Current.UserLoginManager.AuthencationUser(ip))
                {
                    ViewBag.Msg = "您登陆失败超过30次，今天无法登陆，请联系管理员";
                    ViewBag.UserName = userName;

                    //返回结果
                    model.Code = 0;
                    model.Message = "您已经登陆失败超过30次，今天已经无法在重新登陆，请联系管理员";
                    model.Url = url;

                    return Json((model));

                }
                #endregion



                #region 验证登录
             

                passWord = MD5.GetMD5(passWord, "");

                var rememberPassWordFlag = !string.IsNullOrEmpty(chkFlag);

                SoUser soUser = null;
                var b = Manager.Current.UserLoginManager.CheckAndLogin(userName.Trim(), passWord.Trim(), ip, rememberPassWordFlag, out soUser);
                #endregion

                #region 此处处理用户登录成功之后Url跳转


                //用户登录成功之后跳转到网站首页 增加网站首页联盟广告的刷新量
                if (string.IsNullOrEmpty(url))
                {
                    url = ConfigHelper.GetHomeUrl;
                }

                if (b.Code == 1)
                {
                    model.Code = 1;
                    model.Message = b.Message;
                    model.Url = url;
                    model.UserName = soUser.UserName;

                    return Json(model);
                }
                else
                {
                    ViewBag.UserName = userName;
                    ViewBag.Msg = b.Message;

                    model.Code = 0;
                    model.Message = b.Message;
                    model.Url = url;
                    model.UserName = soUser.UserName;

                    return Json(model);
                }

                #endregion

            }
            catch (Exception Exc)
            {
                model.Code = 0;
                model.Message = "登录错误！";
                model.Url = url;

                return Json(model);
            }
            #endregion
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            string code = RandomHelper.GetRandom(4);
            Session["ValidateCode"] = code;
            byte[] bytes = ValidateCodeHelper.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 注销用户
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            if (SOLib.SoLogin.LoginOut())
            {
                return Redirect(Manager.Current.ConfigManager.SoUrl);
            }
            else
            {
                return Content("False");
            }

        }


    }
}