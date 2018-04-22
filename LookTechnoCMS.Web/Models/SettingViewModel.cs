using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookTechnoCMS.Web.Models
{
    public class SettingViewModel
    {
        public int Id { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitleAr { get; set; }
        public string MetaDescriptionAr { get; set; }
        public string MetaKeywordsAr { get; set; }
        public string LinkedinLink { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string YoutubeVideoLink { get; set; }
        public string Telephone { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
             ErrorMessage = "Please Enter Correct Email Address")]

        public string Email { get; set; }
        public string Address { get; set; }
        public string AddressAr { get; set; }
        public string Fax { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}