using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;

namespace LookTechnoCMS.Web.Areas.Admin.Models
{
    public class RoleViewModel
    { 
    
     
        public class CreateRoleViewModel
        {
            [Required]
            public String Name { get; set; }
        }


        public class RoleClaimsViewModel
        {
            public RoleClaimsViewModel()
            {
                ClaimGroups = new List<ClaimGroup>();

                SelectedClaims = new List<String>();
            }

            public String Id { get; set; }

            public String Name { get; set; }

            public List<ClaimGroup> ClaimGroups { get; set; }

            public IEnumerable<String> SelectedClaims { get; set; }


            public class ClaimGroup
            {
                public ClaimGroup()
                {
                    GroupClaimsCheckboxes = new List<SelectListItem>();
                }
                public String GroupName { get; set; }

                public int GroupId { get; set; }

                public List<SelectListItem> GroupClaimsCheckboxes { get; set; }
            }
        }
    }
    public class RoleIndexViewModel
    {
        public String Id { get; set; }

        public String Name { get; set; }
    }
}