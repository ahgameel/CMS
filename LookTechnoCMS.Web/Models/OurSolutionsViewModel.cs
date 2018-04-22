using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class OurSolutionsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public bool? ShowInHomePage { get; set; }
        public string Image { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string MetaTitleAr { get; set; }
        public string MetaDescriptionAr { get; set; }
        public string MetaKeywordsAr { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool ShowHideImage { get; set; }
    }
}