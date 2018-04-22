using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Service.CellService;
using LookTechnoCMS.Service.GeneralSettingService;
using LookTechnoCMS.Service.MenuService;
using LookTechnoCMS.Service.NewsletterSubscriberService;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Infrastructure.Helpers;
using LookTechnoCMS.Web.Models;
using LookTechnoCMS.Data;

namespace LookTechnoCMS.Web.Controllers
{
    public class CommonController : FrontBaseController
    {
        private readonly IMenuService _menuService;
        private readonly ISettingService _settingService;
        private readonly ICellSettingService _cellSettingService;
        private readonly ISubscribersService _subscribersService;
        public CommonController(IMenuService menuService, ISettingService settingService, ICellSettingService cellSettingService, ISubscribersService subscribersService)
        {
            _menuService = menuService;
            _settingService = settingService;
            _cellSettingService = cellSettingService;
            _subscribersService = subscribersService;
        }
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {

                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                //cookie.Expires = DateTime.Now.AddTicks(1);
            }
            Response.Cookies.Add(cookie);
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

           System.Web.HttpContext.Current.Session["culture"] = culture;

           // return RedirectToAction("Index","Home");
            return Redirect(Request.UrlReferrer.ToString());
        }

        [ChildActionOnly]
        public ActionResult TopHeader()
        {
            var settings = _settingService.GetSettings();
            var settingviewmodel = Mapper.Map<GeneralSetting, SettingViewModel>(settings);
            return PartialView("_TopHeader", settingviewmodel);
        }

        public ActionResult Menu()
        {
            //Get the menuItems collection
            var menuitems = _menuService.GetMenuLinks();
            var menuitemsviewmodel = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(menuitems);

            return PartialView("Menu", menuitemsviewmodel);
        }
        public ActionResult MetaWidget()
        {
            var settings = _settingService.GetSettings();
            var settingviewmodel = Mapper.Map<GeneralSetting, SettingViewModel>(settings);
            return PartialView("_MetaWidget", settingviewmodel);
        }
        [ChildActionOnly]
        public ActionResult WhyUs(int cellId)
        {
            var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
            var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
            return PartialView("_Whyus", cellSettingsViewModel);
        }
        [ChildActionOnly]
        public ActionResult HowWeWork(int cellId)
        {
            var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
            var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
            return PartialView("_HowWeWork", cellSettingsViewModel);
        }
         [ChildActionOnly]
        public ActionResult OurVision(int cellId)
        {
            var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
            var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
            return PartialView("_OurVision", cellSettingsViewModel);
        }
         [ChildActionOnly]
         public ActionResult OurMission(int cellId)
         {
             var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
             var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
             return PartialView("_OurMission", cellSettingsViewModel);
         }
         [ChildActionOnly]
         public ActionResult SocialLinks()
         {
             var settings = _settingService.GetSettings();
             var settingviewmodel = Mapper.Map<GeneralSetting, SettingViewModel>(settings);
             return PartialView("_SocialLinks", settingviewmodel);
         }
         public ActionResult QuickLinks()
         {
             //Get the menuItems collection
             var menuitems = _menuService.GetMenuLinks();
             var menuitemsviewmodel = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(menuitems);

             return PartialView("_QuickLinks", menuitemsviewmodel);
         }
         public ActionResult ContactInfo()
         {
             var settings = _settingService.GetSettings();
             var settingviewmodel = Mapper.Map<GeneralSetting, SettingViewModel>(settings);
             return PartialView("_ContactInfo", settingviewmodel);
          
         }
         [ChildActionOnly]
         public ActionResult NewsletterWidget()
         {
             return PartialView("_NewsletterWidget");
         }
         [HttpPost]
         public ActionResult SubscribeNewsletter(string email, string returnUrl)
         {
             if (ModelState.IsValid)
             {
               var   subscribersViewModel=new SubscribersViewModel {DateCreated = DateTime.UtcNow,Email=email};
                 var subscriber = Mapper.Map<SubscribersViewModel, NewsletterSubscriber>(subscribersViewModel);
                 _subscribersService.Add(subscriber);
                 ModelState.Clear();
           
             }
           
             // AddMessage(this, "", "Record has Added Successfully", MessageType.Success);

             return Redirect(returnUrl);
            // return Json(new { ok = true, url = Url.Content("~/") });  

         }
    }
}