using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;
using YRD.Model.DomainModels;
using YRD.Model.EnumModels;
using YRD.Model.ViewModels; 

namespace YRD.Web.Controllers
{
    /// <summary>
    /// 支付管理
    /// </summary>
    public class PaymentController : BaseController
    {
        #region 设置支付密码
        [Authorization(1114)]
        public ActionResult SetPassword()
        {
            ViewSetPayPassword model = new ViewSetPayPassword();
            using (var db = new EFContext())
            {
                var f = db.selshoppaypassword.FirstOrDefault(x => x.ShopID == ShopId);
                if (f == null)
                {
                    model.IsAllowSetPayPassword = true;
                }
                else
                {
                    model.IsAllowSetPayPassword = false;
                }
            }
            return View(model);
        }
        public ActionResult SaveSetPassword(ViewSetPayPassword model)
        {
            ViewBase b = new ViewBase();
            if (model.NewPayPassword.IsNull() || model.ConfirmNewPayPassword.IsNull())
            {
                b.Code = 0;
                b.Message = "密码不能为空";
                return Json(b);
            }
            if (model.NewPayPassword != model.ConfirmNewPayPassword)
            {
                b.Code = 0;
                b.Message = "两次输入的密码不一致";
                return Json(b);
            }
            using (var db = new EFContext())
            {
                string oldpassword = MD5.GetMD5(model.Password, "");
                var selmanager = db.selmanager.FirstOrDefault(x => x.LoginName == UserName && x.LoginPwd == oldpassword);
                if (selmanager == null)
                {
                    b.Code = 0;
                    b.Message = "登录密码输入错误";
                    return Json(b);
                }
                string newpaypassword = MD5.GetMD5(model.NewPayPassword, "");

                var s = new selshoppaypassword()
                {
                    ShopID = ShopId,
                    PayPassword = newpaypassword,
                    DT = DateTime.Now
                };
                db.selshoppaypassword.Add(s);
                db.SaveChanges();
                b.Code = 1;
                b.Url = "/Payment/SetPassword";
                b.Message = "支付密码设置成功";
            }
            return Json(b);
        }
        #endregion
        #region 修改支付密码
        [Authorization(1114)]
        public ActionResult ChangePayPassword()
        {
            ViewChangePassword model = new ViewChangePassword();
            model.UserName = UserName;
            return View(model);
        }
        public ActionResult SaveChangePayPassword(ViewChangePassword model)
        {
            ViewBase b = new ViewBase();
            if (model.NewPassword.IsNull() || model.ConfirmNewPassword.IsNull())
            {
                b.Code = 0;
                b.Message = "密码不能为空";
                return Json(b);
            }
            if (model.OldPassword.ToLower() == model.NewPassword.ToLower())
            {
                b.Code = 0;
                b.Message = "新密码不能跟旧密码相同";
                return Json(b);
            }
            if (model.NewPassword != model.ConfirmNewPassword)
            {
                b.Code = 0;
                b.Message = "两次输入的密码不一致";
                return Json(b);
            }
            if (model.UserName.IsNull())
            {
                b.Code = 0;
                b.Message = "用户名不正确";
                return Json(b);
            }

            using (var db = new EFContext())
            {
                string oldpassword = MD5.GetMD5(model.OldPassword, "");
                var selmanager = db.selshoppaypassword.FirstOrDefault(x => x.ShopID == ShopId && x.PayPassword == oldpassword);
                if (selmanager == null)
                {
                    b.Code = 0;
                    b.Message = "旧密码输入错误";
                    return Json(b);
                }
                string newpassword = MD5.GetMD5(model.NewPassword, "");
                selmanager.PayPassword = newpassword;
                db.SaveChanges();
                b.Code = 1;
                b.Message = "密码修改成功";
                b.Url = "/Payment/SetPassword";
            }
            return Json(b);
        }
        #endregion
    }
}