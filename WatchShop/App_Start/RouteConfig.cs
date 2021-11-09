using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WatchShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
                                new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                   name: "Search",
                   url: "tim-kiem",
                   defaults: new { controller = "Search", action = "Result", id = UrlParameter.Optional },
                   namespaces: new[] { "WatchShop.Controllers" }
               );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
