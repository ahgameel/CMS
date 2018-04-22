using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.GeneralSettingService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin
{
    public class GeneralSettingController : BaseController
    {
        private readonly ISettingService _settingService;

        public GeneralSettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        // GET: Admin/GeneralSetting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var settings = _settingService.GetSettings();
            var settingviewmodel = Mapper.Map<GeneralSetting, SettingViewModel>(settings);

            return View(settingviewmodel);
        }
        [HttpPost]
        public ActionResult Edit(SettingViewModel settingViewModel)
        {
            if (ModelState.IsValid)
            {
                if (settingViewModel != null)
                {
                    settingViewModel.DateCreated = settingViewModel.DateCreated;
                    settingViewModel.DateModified = DateTime.UtcNow;


                    var setting = Mapper.Map<SettingViewModel, GeneralSetting>(settingViewModel);
                    _settingService.Edit(setting);
                    AddMessage(this, "", "Setting has modified  Successfully", MessageType.Success);
                
                }
            }
            return View(settingViewModel);
        }
    }
}