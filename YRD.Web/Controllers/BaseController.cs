using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;
using YRD.Model.ViewModels;
using YRD.SOLib;

namespace YRD.Web.Controllers
{
    public class BaseController : OriginBaseController
    {
        #region 属性
        private string controllerPath;
        protected string ControllerPath
        {
            get
            {
                if (string.IsNullOrEmpty(controllerPath))
                {
                    controllerPath = string.Format("/{0}", ControllerContext.RouteData.Values["controller"].ToString());
                }
                return controllerPath;
            }
        }
        #endregion

        /// <summary>
        /// 当前系统登录用户编号
        /// </summary>
        public string ManagerId
        {
            get
            {
                return Session["ManagerId"].ToString();
            }
        }
        public string ShopId
        {
            get
            {
                return Session["ShopId"].ToString();
            }
        }
        public string ShopName
        {
            get
            {
                return Session["ShopName"].ToString();
            }
        }
        public string UserName
        {
            get
            {
                return Session["UserName"].ToString();
            }
        }
        public string NickName
        {
            get
            {
                return Session["NickName"].ToString();
            }
        }

        public int IsOwner
        {
            get
            {
                return int.Parse(Session["IsOwner"].ToString());
            }
        }




        #region 获取当前用户对象

        #endregion

        #region 重写Initialize   
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //验证权限 TODO

            base.Initialize(requestContext);
            //ViewData["CurrentUser"] = CurrentUser;
            ViewBag.Path = ControllerPath;
            // ViewBag.UserName = UserName;
        }
        #endregion



        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region test

            //filterContext.HttpContext.Session["ManagerId"] = 3;
            //filterContext.HttpContext.Session["ShopId"] = 1;
            #endregion

            #region home

            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;
            string tempurl = string.Format("/{0}/{1}", controllerName, actionName);
            //var selpemit = DB.selpemit.Value.FirstOrDefault(x => x.Url == tempurl);
            //if (selpemit == null)
            //{
            //    filterContext.Controller.ViewBag.menuid = 0;
            //}
            //else
            //{
            //    filterContext.Controller.ViewBag.menuid = selpemit.ID;
            //}



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
                    string regexString = ConfigHelper.GetWwwUrl + @":\d{0,5}";
                    Regex regex = new Regex(regexString);
                    if (regex.IsMatch(url))
                    {
                        url = regex.Replace(url, ConfigHelper.GetWwwUrl);
                    }

                    var rawurl = System.Web.HttpUtility.UrlEncode(url);

                    //string loginSoUrl = ConfigHelper.GetSoLoginUrl;
                    string loginSoUrl = string.Format("{0}?url={1}", ConfigHelper.GetSoUrl, System.Web.HttpUtility.UrlEncode(rawurl));
                    string newurl = loginSoUrl;
                    filterContext.Result = new RedirectResult(newurl);
                }
            }
            else
            {


                using (var db = new EFContext())
                {
                    //控制左边菜单显示
                    var query = new List<ViewPemit>();
                    var selshop = db.selshop.Where(x => x.ID == model.ShopId).Select(x => new { x.ID, x.AuditStatus, x.VersionID }).FirstOrDefault();
                    if (selshop.AuditStatus != 1)
                    {
                        query.Add(new ViewPemit() { ID = "1000", IsDel = 0, PemitType = 0, Title = "完善资料", Sort = 99, Url = "/SM/CompleteInfo", ParentID = "8" });
                    }
                    //查询网店所有者用户拥有的权限

                    var selmanagerowner = db.selmanager.FirstOrDefault(x => x.ShopID == model.ShopId && x.IsOwner == 1);
                    var selmanagerroleowner = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == selmanagerowner.ID);
                    var rolepemitidowner = db.selrole_pemit.Where(x => x.SelRoleID == selmanagerroleowner.SelRoleID).Select(x => x.SelPemitID).ToList();

                    var selmanagerrole = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == model.ManagerId);
                    var rolepemitid = db.selrole_pemit.Where(x => x.SelRoleID == selmanagerrole.SelRoleID).Select(x => x.SelPemitID).ToList();



                    if (model.IsOwner == 1)
                    {
                        query = db.selpemit.Where(x => x.IsMenu == 1)
                                .Where(x => rolepemitid.Contains(x.ID))
                                .Select(x => new ViewPemit() { ID = x.ID, Title = x.Title, ParentID = x.ParentID, IsDel = x.IsDel, ImgUrl = x.ImgUrl, PemitType = x.PemitType, Sort = x.Sort, Url = x.Url }).ToList();

                    }
                    else
                    {

                        //管理员权限下面的 有效权限
                        query = db.selpemit.Where(x => x.IsMenu == 1)
                               .Where(x => rolepemitid.Contains(x.ID))
                               .Where(x => rolepemitidowner.Contains(x.ID))
                               .Select(x => new ViewPemit() { ID = x.ID, Title = x.Title, ParentID = x.ParentID, IsDel = x.IsDel, ImgUrl = x.ImgUrl, PemitType = x.PemitType, Sort = x.Sort, Url = x.Url }).ToList();
                    }


                    filterContext.Controller.ViewBag.MenuList = query;
                    filterContext.Controller.ViewBag.menuid = 0;
                }

                if (model.UserLoginType == (int)UserLoginType.UserSelf || model.UserLoginType == (int)UserLoginType.Manager)
                {
                    if (filterContext.HttpContext.Session["SoLibID"] == null || filterContext.HttpContext.Session["SoLibID"].ToString() != soLibID)
                    {

                        filterContext.HttpContext.Session["SoLibID"] = soLibID;
                        filterContext.HttpContext.Session["ManagerId"] = model.ManagerId;
                        filterContext.HttpContext.Session["UserName"] = model.UserName;
                        filterContext.HttpContext.Session["NickName"] = model.NickName;
                        filterContext.HttpContext.Session["ShopId"] = model.ShopId;
                        filterContext.HttpContext.Session["ShopName"] = model.ShopName;
                        filterContext.HttpContext.Session["IsOwner"] = model.IsOwner;
                    }

                }
                else if (model.UserLoginType == (int)UserLoginType.SubAccount)
                {
                    if (filterContext.HttpContext.Session["SoLibID"] == null || filterContext.HttpContext.Session["SoLibID"].ToString() != soLibID)
                    {
                        filterContext.HttpContext.Session["SoLibID"] = soLibID;
                        filterContext.HttpContext.Session["ManagerId"] = model.ManagerId;
                        filterContext.HttpContext.Session["UserName"] = model.UserName;
                        filterContext.HttpContext.Session["NickName"] = model.NickName;
                        filterContext.HttpContext.Session["ShopId"] = model.ShopId;
                        filterContext.HttpContext.Session["ShopName"] = model.ShopName;
                        filterContext.HttpContext.Session["IsOwner"] = model.IsOwner;
                    }

                }
                else
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())//处理Ajax请求
                    {
                        JsonResult jr = new JsonResult();
                        jr.Data = new { Code = 0, Message = "没有访问权限！", Data = "" };
                        jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                        filterContext.Result = jr;
                    }
                    else
                    {
                        string wwwUrl = ConfigHelper.GetWwwUrl;
                        string url = wwwUrl;
                        filterContext.Result = new RedirectResult(url);
                    }
                }
                filterContext.Controller.ViewBag.UserName = model.UserName;

                string VersionName = string.Empty;
                //获取店铺等级
                using (var db = new EFContext())
                {
                    var selshop = db.selshop.FirstOrDefault(x => x.ID == model.ShopId);
                    model.ShopName = selshop.ShopName;
                    var sysversion = db.sysversion.FirstOrDefault(x => x.VersionID == selshop.VersionID);
                    if (sysversion != null)
                    {
                        VersionName = sysversion.Name;
                    }

                }
                filterContext.Controller.ViewBag.ShopName = model.ShopName;
                filterContext.Controller.ViewBag.VersionName = VersionName;


            }

            #endregion
        }





        #region 查询并分页
        /// <summary>
        /// 带分页列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="total"></param>
        /// <param name="exdata"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public string ToPageWithPaging(IEnumerable data, int total, object exdata = null, string dataFormat = "yyyy-MM-dd HH:mm:ss")
        {
            if (exdata != null)
            {
                var result = new
                {
                    draw = Request["draw"],
                    recordsTotal = total,
                    recordsFiltered = total,
                    data = data,
                    exdata = exdata
                };
                return result.ToJsonString(dataFormat);
            }
            else
            {
                var result = new
                {
                    draw = Request["draw"],
                    recordsTotal = total,
                    recordsFiltered = total,
                    data = data
                };
                return result.ToJsonString(dataFormat);
            }

        }
        #endregion
        #region 查询不分页
        /// <summary>
        /// 不带分布列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="exdata"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public string ToPageNoPaging(IEnumerable data, object exdata = null, string dataFormat = "yyyy-MM-dd HH:mm:ss")
        {
            if (exdata != null)
            {
                var result = new
                {
                    data = data,
                    exdata = exdata
                };
                return result.ToJsonString(dataFormat);
            }
            else
            {
                var result = new
                {
                    data = data
                };
                return result.ToJsonString(dataFormat);
            }

        }
        #endregion

        #region 导出Excel
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <typeparam name="T">集合列表里对象的类型</typeparam>
        /// <param name="list">数据列表</param>
        /// <returns></returns>
        protected FileResult ToExcel(IEnumerable list, string xmlFileName, string title = "数据导出标题")
        {
            #region 获取XML
            XMLHelp xmlhelp = new XMLHelp(string.Format("/XmlConfig/excel/{0}.xml", xmlFileName));
            var fields = xmlhelp.GetList<Xml_Field>().Select(a => new KeyValuePair<string, string>(a.code, a.name)).ToList();
            #endregion

            var dirPath = Server.MapPath("/upload/toexcel/");
            if (System.IO.Directory.Exists(dirPath) == false)
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            var filePath = string.Format("{0}{1}.xls", dirPath, WebTools.getGUID());
            ExcelHelp.ToExcelByNPOI(list, filePath, fields, title);
            string fileDownloadName = string.Format("{0}.xls", title);
            return File(filePath, "application/vnd.ms-excel", fileDownloadName);
        }
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <typeparam name="T">集合列表里对象的类型</typeparam>
        /// <param name="list">数据列表</param>
        /// <returns></returns>
        protected FileResult ToExcel(DataTable list, string xmlFileName)
        {
            #region 获取XML
            XMLHelp xmlhelp = new XMLHelp(string.Format("/XmlConfig/excel/{0}.xml", xmlFileName));
            var fields = xmlhelp.GetList<Xml_Field>().Select(a => new KeyValuePair<string, string>(a.code, a.name)).ToList();
            #endregion
            var dirPath = Server.MapPath("/upload/toexcel/");
            if (System.IO.Directory.Exists(dirPath) == false)
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            var filePath = string.Format("{0}{1}.xls", dirPath, WebTools.getGUID());
            ExcelHelp.ToExcelByNPOI(list, filePath, fields);
            return File(filePath, "application/vnd.ms-excel");
        }
        #endregion


    }
}