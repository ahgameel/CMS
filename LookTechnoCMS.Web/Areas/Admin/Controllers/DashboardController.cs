using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.GData.Analytics;
using Google.GData.Client;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        private const string ApplicationName = "looktechno";
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
           
            return View();
        }
        //public ActionResult Auth()
        //{
        //    const string scope = "https://www.google.com/analytics/feeds/";
        //    var next = Url.Action("AuthResponse");
        //    var url = AuthSubUtil.getRequestUrl(next, scope, false, true);
        //    return Redirect(url);
        //}
        //public ActionResult AuthResponse(string token)
        //{
        //    var sessionToken = AuthSubUtil.exchangeForSessionToken(token, null);

        //    return View(sessionToken);
        //}
    }
}