using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.ContactusService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class ContactUsController : BaseController
    {

        private readonly IContactUsService _contactUsService;


        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        // GET: Admin/ContactUs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetContactMessages([DataSourceRequest] DataSourceRequest request)
        {
            var contactMessages = _contactUsService.GetContactMessages();
            var contactUsViewModel = Mapper.Map<IEnumerable<Contatctu>, IEnumerable<ContactUsViewModel>>(contactMessages);
            return Json(contactUsViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}