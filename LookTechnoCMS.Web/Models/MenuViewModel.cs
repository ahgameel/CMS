using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Link Title is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Link Title Arabic is required")]
        public string NameAr { get; set; }
        public string Url { get; set; }
        public int PageID { get; set; }
        public bool? Active { get; set; }
        public int? ParentMenuId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }

    public class ListMenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int PageID { get; set; }
        public bool Active { get; set; }
        public int? ParentMenuId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}