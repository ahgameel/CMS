using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class BrandsViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Image { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool ShowHideImage { get; set; }
    }
}