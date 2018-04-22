﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Infrastructure.Helpers;
using LookTechnoCMS.Web.Infrastructure.ValidationMessage;

namespace LookTechnoCMS.Web.Controllers
{
    public class FrontBaseController : Controller
    {
        public static ValidateMessage AddMessage(Controller controller, string title, string message, MessageType messageType)
        {
            var toastr = controller.TempData["Toastr"] as ValidateMessageContainer;
            toastr = toastr ?? new ValidateMessageContainer();

            var toastMessage = toastr.AddMessage(title, message, messageType);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe


            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            return base.BeginExecuteCore(callback, state);
        }
    }
}