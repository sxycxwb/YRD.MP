using System.Web.Mvc;
using System.Web.Routing;

namespace YRD.SO
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Ignore("favicon.ico");
            RouteTable.Routes.Ignore("{filename}.html/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}