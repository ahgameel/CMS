using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.ContactusService;
using LookTechnoCMS.Service.GeneralSettingService;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IContactUsService _contactUsService;
        public ContactController(ISettingService settingService, IContactUsService contactUsService)
        {
            _settingService = settingService;
            _contactUsService = contactUsService;
        }
        //
        // GET: /Contact/
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ContactInfo()
        {
            var settings = _settingService.GetSettings();
            var settingviewmodel = Mapper.Map<GeneralSetting, SettingViewModel>(settings);
            return PartialView("_ContactInfo", settingviewmodel);
           
        }
        [HttpPost]
        public ActionResult SubmitContactForm(ContactUsViewModel contactUsViewModel)
        {
            if (ModelState.IsValid)

                if (contactUsViewModel != null)
                {

                    contactUsViewModel.DateCreated = DateTime.UtcNow;
                    var contact = Mapper.Map<ContactUsViewModel, Contatctu>(contactUsViewModel);
                    _contactUsService.Add(contact);
                }

            return RedirectToAction("Index");
        }
	}
}