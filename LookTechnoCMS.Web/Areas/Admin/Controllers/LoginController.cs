using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using LookTechnoCMS.Service.SecurityService;
using LookTechnoCMS.Web.Areas.Admin.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;

        public LoginController(UserManager userManager,SignInManager signInManager)
        {
             _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await _userManager.SignInAsync(AuthenticationManager, user, model.RememberMe);
                    ViewData["username"] = user.UserName;
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");


                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }

 
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Login");
        }



    }
}