using System;
using LookTechnoCMS.Data;
using Microsoft.Owin.Security;


namespace LookTechnoCMS.Service.SecurityService
{
    public class SignInManager : Microsoft.AspNet.Identity.Owin.SignInManager<ApplicationUser, String>
    {
        public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}