using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class PageViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Page Title is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Page Title is required")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "Page Body is required")]
        public string Body { get; set; }
        [Required(ErrorMessage = "Page Body is required")]
        public string BodyAr { get; set; }
            [Required(ErrorMessage = "Frindly Url Title is required")]
        public string NavigationUrl { get; set; }
        //[Required(ErrorMessage = "Meta Keywords is required")]
        public string MetaKeywords { get; set; }
        //[Required(ErrorMessage = "Meta Description is required")]
        public string MetaDescription { get; set; }
        //[Required(ErrorMessage = "Meta Title  is required")]
        public string MetaTitle { get; set; }
        public string MetaTitleAr { get; set; }
        public string MetaDescriptionAr { get; set; }
        public string MetaKeywordsAr { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }














    }

    public class ListPageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
    }
}