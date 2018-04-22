using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.SecurityService;
using LookTechnoCMS.Web.Areas.Admin.Models;
using LookTechnoCMS.Web.Controllers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LookTechnoCMS.Web.Infrastructure;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
      
    public class UsersController : BaseController
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly SignInManager _signInManager;
        private String userId;
        public UsersController(UserManager userManager, SignInManager signInManager, RoleManager roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            var user = _userManager.Users.ToList();
            var users = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserIndexViewModel>>(user);
            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
       
        

        public ActionResult Create()
        {
            return View();
        }

       [HttpPost]
        public async Task<ActionResult> Create(CreateUserViewModel model, string submit)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded && submit == "Save")
                {
                    var roleName = _roleManager.FindById(model.RoleId);

                    //_userManager.AddToRole(user.Id, roleName.Name);
                    await _userManager.SignInAsync(AuthenticationManager, user, isPersistent: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
               
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Users");
                }
                else if (result.Succeeded && submit == "SaveAndContinue")
                {
                    var roleName = _roleManager.FindById(model.RoleId);

                    //_userManager.AddToRole(user.Id, roleName.Name);
                    await _userManager.SignInAsync(AuthenticationManager, user, isPersistent: false);
                    
                    ModelState.Clear();
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return View();
           
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
       public async Task<ActionResult> Edit(string id)
       {
           userId = id;
          IList<string> roleName=  _userManager.GetRoles(id);
         // var role= _roleManager.FindByName(roleName.ToString());
  
          var role = await _roleManager.FindByNameAsync(roleName.ToString()); 

           var user = await _userManager.FindByIdAsync(id);
          var viewModel = new EditUserViewModel()
           {
               UserName = user.UserName,
               Password = user.PasswordHash,
              Email = user.Email
          
           };
           return View(viewModel);
        }
        [HttpPost]
       public async Task<ActionResult> Edit(EditUserViewModel model, string submit)
       {
           
           if (ModelState.IsValid)
           {
               var hasher = new PasswordHasher();
               var userexist= await _userManager.FindByIdAsync(model.Id);
               userexist.Email = model.Email;
               userexist.UserName = model.UserName;
       
               var newpassword = hasher.HashPassword(model.Password);
               userexist.PasswordHash = newpassword;
              // var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email};
               //var user = Mapper.Map<EditUserViewModel, ApplicationUser>(model);          
              await _userManager.ResetPasswordAsync(model.Id, "", model.Password);
               IdentityResult result = _userManager.Update(userexist);
               if (result.Succeeded && submit == "Save")
               {
                  // await _userManager.SignInAsync(AuthenticationManager, userexist, isPersistent: false);
                  
                   // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                   // Send an email with this link
                   // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                   // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                   // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                   AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                   return RedirectToAction("Index", "Users");
               }
               if (result.Succeeded && submit == "SaveAndContinue")
               {
                   await _userManager.SignInAsync(AuthenticationManager, userexist, isPersistent: false);
                   AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                   return View(model);
               }
               AddErrors(result);
           }

           // If we got this far, something failed, redisplay form
           return View(model);
       }
        public async Task<ActionResult> Delete(string id)
        {
            var user =  await _userManager.FindByIdAsync(id);
            _userManager.Delete(user);
  
            return Json(new { ok = true, Message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success) },
            JsonRequestBehavior.AllowGet);
         
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public JsonResult GetAllRoles()
        {
            var allRoles = _roleManager.Roles.ToList();
            return Json(allRoles, JsonRequestBehavior.AllowGet);
        }

    }
}
