using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class CellViewModel
    {
        public int Id { get; set; }

        public string CellTitle { get; set; }
        public string CellTitleAr { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? ShowHide { get; set; }
    }
}