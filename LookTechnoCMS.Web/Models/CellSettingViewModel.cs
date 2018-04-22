using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class CellSettingViewModel
    {
        public int Id { get; set; }
        public int CellId { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool ShowHideImage { get; set; }
    
    }
}