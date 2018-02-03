using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRD.Web
{
    public class ErrorFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            string strController = filterContext.RouteData.Values["controller"].ToString();
            string strAction = filterContext.RouteData.Values["action"].ToString();
            HandleErrorInfo hei = new HandleErrorInfo(filterContext.Exception, strController, strAction);
            filterContext.Controller.ViewData.Model = hei;

            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData,

            };

            Exception Error = filterContext.Exception;
            filterContext.ExceptionHandled = true;
        }
    }
}