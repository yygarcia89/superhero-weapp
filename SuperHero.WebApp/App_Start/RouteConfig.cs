using System.Web.Mvc;
using System.Web.Routing;

namespace SuperHero.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Error",
               url: "{controller}/{action}",
               defaults: new { controller = "Error", action = "Index" }
           );
        }
    }
}
