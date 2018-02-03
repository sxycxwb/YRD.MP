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
    /// 账户管理
    /// </summary>
    public class AccountSafeController : BaseController
    {
        #region 修改密码
        [Authorization(1112)]
        public ActionResult ChangePassword()
        {
            ViewChangePassword model = new ViewChangePassword();
            model.UserName = UserName;
            return View(model);
        }
        public ActionResult SaveChangePassword(ViewChangePassword model)
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
                var selmanager = db.selmanager.FirstOrDefault(x => x.LoginName == UserName && x.LoginPwd == oldpassword);
                if (selmanager == null)
                {
                    b.Code = 0;
                    b.Message = "旧密码输入错误";
                    return Json(b);
                }
                string newpassword = MD5.GetMD5(model.NewPassword, "");
                selmanager.LoginPwd = newpassword;
                db.SaveChanges();
                b.Code = 1;
                b.Message = "密码修改成功";
                b.Url = ConfigHelper.GetSoUrl;
            }
            return Json(b);
        }
        #endregion
    }
}