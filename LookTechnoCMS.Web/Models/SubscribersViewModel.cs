using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class SubscribersViewModel
    {
        public int Id { get; set; }
         [Required]
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}