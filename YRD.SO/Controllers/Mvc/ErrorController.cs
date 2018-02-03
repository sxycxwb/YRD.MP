using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string errorCode = "404")
        {
            var errorMsg = string.Empty;
            if (errorCode == "404")
            {
                errorMsg = "你找的页面未找到！";
            }
            if (errorCode == "500")
            {
                errorMsg = "服务器出现错误，请联系网站管理人员处理！";
            }
            ViewBag.ErrorMessage = errorMsg;
            ViewBag.SiteName = "今农网";
            return View();
        }

    }
}
