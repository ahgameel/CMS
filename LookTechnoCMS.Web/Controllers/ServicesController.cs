using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.OurServicesService;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IOurServicesService _ourServicesService;

        public ServicesController(IOurServicesService ourServicesService)
        {
            _ourServicesService = ourServicesService;
        }
        // GET: Services
        public ActionResult Index()
        {
            var services = _ourServicesService.GetAllServices();
            var settingviewmodel = Mapper.Map<IEnumerable<OurService>, IEnumerable<OurServicesViewModel>>(services);
            return View(settingviewmodel);
        }
        public ActionResult ListItem(int serviceId)
        {
            var service = _ourServicesService.GetServiceById(serviceId);
            var serviceviewmodel = Mapper.Map<OurService, OurServicesViewModel>(service);
            return PartialView("_ListItem", serviceviewmodel);
        }
    }
}