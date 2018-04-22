using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LookTechnoCMS.Web.App_Start;

namespace LookTechnoCMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Run();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        
        {
            var cookie = HttpContext.Current.Request.Cookies["_culture"];
            var name = cookie != null ? cookie.Value : null;
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

           

            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(name);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
          
        }
    }
}
