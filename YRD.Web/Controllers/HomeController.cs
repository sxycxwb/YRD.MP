using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;

namespace YRD.Web.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            return View();
        }

        #region 空页面
        public ActionResult Null()
        {

            return Content("");
        }
        #endregion
    }
}