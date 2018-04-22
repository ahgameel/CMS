using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LookTechnoCMS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ContentPage",
                "{PageName}",
                new
                {
                    controller = "ContentPage",
                    action = "Index"


                });
            routes.MapRoute("Services", "Services/Index", new { controller = "Services", action = "Index" });
            routes.MapRoute("Solutions", "Solution/Index", new { controller = "Solution", action = "Index" });
            routes.MapRoute("Products", "Products/Index", new { controller = "Products", action = "Index" });
            routes.MapRoute("Contact", "Contact/Index", new { controller = "Contact", action = "Index" });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
