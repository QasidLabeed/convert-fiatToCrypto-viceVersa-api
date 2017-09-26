using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restful_API_for_conversion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            

            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "converter", action = "", id = UrlParameter.Optional }
            );
        }
    }
}
