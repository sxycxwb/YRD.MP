
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;

using Newtonsoft.Json;

using System.Text.RegularExpressions;
using YRD.SOLib;

namespace YRD.Web
{
    /// <summary>
    /// 权限控制操作
    /// </summary>
    public class AuthorizationAttribute : ActionFilterAttribute
    {

        public class Menu
        {
            public string MenuId { get; set; }
        }

        private int menuId;

        public AuthorizationAttribute(int menuId = 0)
        {
            this.menuId = menuId;
            this.Order = 2;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            #region home
            string soLibID = SoLogin.IsLogin();

            var model = SoLogin.GetUserModel();

            if (string.IsNullOrEmpty(soLibID) || model == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())//处理Ajax请求
                {
                    JsonResult jr = new JsonResult();
                    jr.Data = new { Code = -200, Message = "登录超时,请重新登录再操作！", Data = "", Url = ConfigHelper.GetSoUrl };
                    jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = jr;
                }
                else
                {
                    string url = filterContext.HttpContext.Request.Url.ToString();
                    string regexString = ConfigHelper.GetHomeUrl + @":\d{0,5}";
                    Regex regex = new Regex(regexString);
                    if (regex.IsMatch(url))
                    {
                        url = regex.Replace(url, ConfigHelper.GetHomeUrl);
                    }

                    var rawurl = System.Web.HttpUtility.UrlEncode(url);

                    //string loginSoUrl = ConfigHelper.GetSoLoginUrl;
                    string loginSoUrl = string.Format("{0}?url={1}", ConfigHelper.GetSoUrl, rawurl);
                    string newurl = loginSoUrl;
                    filterContext.Result = new RedirectResult(newurl);
                }
            }
            else
            {

                using (var db = new EFContext())
                {
                    var query = new List<Menu>().AsQueryable();

                    var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopId);

                    var selmanagerowner = db.selmanager.FirstOrDefault(x => x.ShopID == model.ShopId && x.IsOwner == 1);
                    var selmanagerroleowner = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == selmanagerowner.ID);
                    var rolepemitidowner = db.selrole_pemit.Where(x => x.SelRoleID == selmanagerroleowner.SelRoleID).Select(x => x.SelPemitID).ToList();

                    var selmanagerrole = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == model.ManagerId);
                    var rolepemitid = db.selrole_pemit.Where(x => x.SelRoleID == selmanagerrole.SelRoleID).Select(x => x.SelPemitID).ToList();
                    if (model.IsOwner == 1)
                    {
                        query = db.selpemit.Where(x => x.IsMenu == 1)
                                .Where(x => rolepemitid.Contains(x.ID))
                                .Select(x => new Menu { MenuId = x.ID });

                    }
                    else
                    {
                        //管理员权限下面的 有效权限

                        query = db.selpemit.Where(x => x.IsMenu == 1)
                               .Where(x => rolepemitid.Contains(x.ID))
                               .Where(x => rolepemitidowner.Contains(x.ID))
                               .Select(x => new Menu() { MenuId = x.ID });
                    }


                    var listmenu = query.ToList();

                    bool hasAuthorization = false;
                    var f = listmenu.FirstOrDefault(a => a.MenuId == menuId.ToString());
                    if (f != null)
                    {
                        hasAuthorization = true;
                    }

                    if (!hasAuthorization)//没有权限
                    {
                        string redirecturl = string.Format("{0}/{1}/ErrorNopermit", ConfigHelper.GetHomeUrl, "Common");

                        if (filterContext.HttpContext.Request.IsAjaxRequest())//处理Ajax请求
                        {
                            JsonResult jr = new JsonResult();
                            jr.Data = new { Code = -200, Message = "没有访问权限！", Data = "", Url = redirecturl };
                            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                            filterContext.Result = jr;
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult(redirecturl);
                        }
                    }
                    else
                    {
                        base.OnActionExecuting(filterContext);
                    }

                }
            }


            #endregion
        }

    }
}