using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public int? ParentCategoryId { get; set; }
        public string ImagePath { get; set; }
        public string LargeImage { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}