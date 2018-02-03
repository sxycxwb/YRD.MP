using YRD.SOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.SO.Controllers.Mvc
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

           


            string soLibID = YRD.SOLib.SoLogin.IsLogin();

            var model = YRD.SOLib.SoLogin.GetUserModel();
            if (string.IsNullOrEmpty(soLibID) || model == null)
            {
                if (Session.Count > 0)
                {
                    Session.Clear();
                }
                return View();
            }
            if (Session["SoLibID"] == null || Session["SoLibID"].ToString() != soLibID)
            {
                Session["SoLibID"] = soLibID;
                Session["UserName"] = model.UserName;
                Session["NickName"] = model.NickName;
            }
            ViewData["b"] = Session["UserName"].ToString();
            return View();
        }

        public ContentResult LoginOut()
        {
            bool b = SoLogin.LoginOut();
            return Content(b.ToString());
        }
    }
}