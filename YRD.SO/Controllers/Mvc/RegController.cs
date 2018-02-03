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
using YRD.Model;
using System.Collections.Generic;
using YRD.Model.ViewModels;
using YRD.Model.DataModels;


namespace YRD.SO.Controllers.Mvc
{
    public class RegController : BaseController
    {

        public ActionResult Index()
        {
            var tg = Request["tg"];
            if (string.IsNullOrEmpty(tg))
            {
                tg = "888888";
            }
            ViewBag.tg = tg;
            return View();
        }
        [HttpPost]
        public JsonResult UserReg(FormCollection form)
        {
            #region field
            ViewUserReg b = new ViewUserReg();

            DateTime dt1 = DateTime.Now;

            var iLog = log4net.LogManager.GetLogger("LogToTXT");

            //仿照sso添加登录信息模型
            string msg = string.Empty;
            bool flag = false;
            string tg = form.Get("tg");
            string userName = form.Get("userName");
            string password = form.Get("password");
            string cpassword = form.Get("cpassword");
            string email = form.Get("email");
            string phone = form.Get("phone");
            string validatecode = form.Get("validatecode");
            string validateid = form.Get("validateid");
            #endregion

            #region 开始验证

            #region 判断用户密码是否为空
            if (string.IsNullOrEmpty(validateid))
            {
                flag = true;
                msg = string.Format("验证码不能为空！");
            }

            if (string.IsNullOrEmpty(validatecode))
            {
                flag = true;
                msg = string.Format("验证码不能为空！");
            }

            if (password != cpassword)
            {
                flag = true;
                msg = string.Format("两次输入的密码不相同！");
            }

            if (string.IsNullOrEmpty(cpassword))
            {
                flag = true;
                msg = string.Format("确认密码不能为空！");
            }

            if (string.IsNullOrEmpty(password))
            {
                flag = true;
                msg = string.Format("密码不能为空！");
            }

            if (string.IsNullOrEmpty(email))
            {
                flag = true;
                msg = string.Format("邮箱不能为空！");
            }
            if (string.IsNullOrEmpty(userName))
            {
                flag = true;
                msg = string.Format("用户名不能为空！");
            }
            #endregion

            #region 开始校验
            if (Session["ValidateCode"] == null || validatecode != Session["ValidateCode"].ToString())
            {
                flag = true;
                msg = string.Format("验证码输入不正确！");
            }
            if (Session["ValidateId"] == null || validateid != Session["ValidateId"].ToString())
            {
                flag = true;
                msg = string.Format("验证码输入不正确！");
            }
            if (Session["Email"] == null || email != Session["Email"].ToString())
            {
                flag = true;
                msg = string.Format("验证码输入不正确！");
            }
            #endregion


            #region 开始判断
            if (flag)
            {

                ViewBag.Email = email;
                ViewBag.UserName = userName;
                ViewBag.Phone = phone;

                b.Code = 0;
                b.Message = msg;
                return Json(b);
            }

            var bbb = RegexHelper.CheckPassword(password);
            if (bbb.Code == 0)
            {
                b.Code = 0;
                b.Message = bbb.Message;
                return Json(b);
            }

            var bbbb = RegexHelper.CheckUserName(userName);
            if (bbbb.Code == 0)
            {
                b.Code = 0;
                b.Message = bbbb.Message;
                return Json(b);
            }
            #endregion

            #endregion

            #region 用户注册
            try
            {
                #region httpclient

                var apiUrl = ConfigHelper.GetApiUrl;
                var url = string.Format(apiUrl + "/api/so/postRegister");

                using (var http = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new Dictionary<string, string>()       
                            { 
                                  {"safecode",SafeCodeHelper.GetSafeCode},
                                  {"username",userName},
                                  {"password",password},
                                  {"email",email} ,
                                  {"tg",tg} 
                             });

                    var response = http.PostAsync(url, content).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        NewBase<ExRegUser> bb = JsonConvert.DeserializeObject<NewBase<ExRegUser>>(response.Content.ReadAsStringAsync().Result);
                        if (bb.Code == 1)
                        {
                            b.Code = 1;
                            //采用服务端的返回提示
                            // b.Message = "注册成功！";
                            b.Url = ConfigHelper.GetHomeUrl;
                            b.Message = bb.Message;

                            //清理注册Session
                            Session["ValidateCode"] = null;

                            Session["ValidateId"] = null;

                            Session["Email"] = null;

                            //登录成功之后 默认用户登录 然后跳转到用户后台
                            SoUser sm = new SoUser();
                            sm.UserName = userName;
                            sm.NickName = userName;
                            sm.IP = SM.Current.IPManager.GetIP();
                            sm.ManagerId = bb.Data.UGUID;
                            bool isLogin = SoLogin.Login(sm);
                            return Json(b);

                        }
                        else
                        {
                            b.Code = 0;
                            //采用服务端的返回提示
                            //b.Message = "注册失败！";
                            b.Message = bb.Message;
                            return Json(b);
                        }
                    }
                    else
                    {
                        b.Code = 0;
                        b.Message = response.ReasonPhrase;
                        return Json(b);
                    }
                }
                #endregion
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "注册异常！";
                return Json(b);
            }
            #endregion

        }



        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        //public ActionResult GetValidateCode()
        //{
        //    string code = RandomHelper.GetRandom(6);
        //    Session["ValidateCode"] = code;
        //    byte[] bytes = ValidateCodeHelper.CreateValidateGraphic(code);
        //    return File(bytes, @"image/jpeg");
        //}
        [HttpPost]
        public JsonResult GetValidateCode(FormCollection form)
        {
            #region field

            NewBase<string> b = new NewBase<string>();

            bool flag = false;
            string userName = form.Get("userName");
            string email = form.Get("email");
            #endregion

            #region 开始验证

            #region 判断用户密码是否为空

            if (string.IsNullOrEmpty(email))
            {
                flag = true;
                b.Message = string.Format("邮箱不能为空！");
            }
            if (string.IsNullOrEmpty(userName))
            {
                flag = true;
                b.Message = string.Format("用户名不能为空！");
            }
            #endregion

            #region 开始判断
            if (flag)
            {
                b.Code = 0;
                return Json(b);
            }

            #endregion

            #endregion

            string vaildatecode = RandomHelper.GetRandom(6);
            Session["ValidateCode"] = vaildatecode;

            var ValidateId = WebTools.getGUID();

            Session["ValidateId"] = ValidateId;

            Session["Email"] = email;

            #region 获取验证码
            try
            {
                //var p = new Dictionary<string, string>() { { "username", userName }, { "email", email }, { "vaildatecode", vaildatecode } };
                //var result = PostAsync<Base>("postValidateCode", p);
                //if (result.Code == 1)
                //{
                //    b.Code = 1;
                //    b.Message = result.Message;
                //    b.Data = ValidateId;
                //}
                //else
                //{
                //    b.Code = 0;
                //    b.Message = result.Message;
                //    b.Data = ValidateId;
                //}
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = "验证码获取失败！";
                b.Description = Exc.ToString();
                var iLog = log4net.LogManager.GetLogger("LogToTXT");
                iLog.Info(Exc.ToString());

            }
            #endregion
            return Json(b);
        }

    }
}
//                   _ooOoo_
//                  o8888888o
//                  88" . "88
//                  (| -_- |)
//                  O\  =  /O
//               ____/`---'\____
//             .'  \\|     |//  `.
//            /  \\|||  :  |||//  \
//           /  _||||| -:- |||||-  \
//           |   | \\\  -  /// |   |
//           | \_|  ''\---/''  |   |
//           \  .-\__  `-`  ___/-. /
//         ___`. .'  /--.--\  `. . __
//      ."" '<  `.___\_<|>_/___.'  >'"".
//     | | :  `- \`.;`\ _ /`;.`/ - ` : | |
//     \  \ `-.   \_ __\ /__ _/   .-` /  /
//======`-.____`-.___\_____/___.-`____.-'======
//                   `=---='
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//       佛祖保佑       永不死机
//       心外无法       法外无心