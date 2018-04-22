using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class HomeSliderViewModel
    {
        public int Id { get; set; }
        public string SlideTitle { get; set; }
        public string SlideImage { get; set; }
        public string HasLink { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ServiceOfferId { get; set; }
        public bool ShowHideImage { get; set; }
    }
}