using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;


namespace LookTechnoCMS.Data
{
    public class ApplicationRole : IdentityRole
    {
        private const String CacheKey = "4BA44A3F-F728-42D8-9387-7577EDC0DD99_Role_Claims_";

        public static string GetCacheKey(String roleName)
        {
            return CacheKey + roleName;
        }

        public ICollection<AspNetRoleClaim> RoleClaims { get; set; }
    }
}