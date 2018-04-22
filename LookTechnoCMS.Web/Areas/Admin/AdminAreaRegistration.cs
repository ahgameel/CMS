using System.Web.Mvc;

namespace LookTechnoCMS.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                 "LTPanel",
                "LTPanel/{controller}/{action}/{id}",
                new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}