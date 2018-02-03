using YRD.SO.Common;
using YRD.SO.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;

namespace YRD.SO
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SOLib.SoLogin.CookieDoman = ConfigHelper.GetCookieDomain;

        }
    }
}
