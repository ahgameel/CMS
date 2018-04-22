using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Service.BrandService;
using LookTechnoCMS.Service.CellService;
using LookTechnoCMS.Service.SliderService;

using LookTechnoCMS.Data;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly ISlider _slider;
        private readonly ICellSettingService _cellSettingService;
        private readonly IBrandSliderService _brandSliderService;
        public HomeController(ISlider slider, ICellSettingService cellSettingService,IBrandSliderService brandSliderService)
        {
            _slider = slider;
            _cellSettingService = cellSettingService;
            _brandSliderService = brandSliderService;
        }
          
        public ActionResult Index()
        {
          
            return View();
        }
        [ChildActionOnly]
        public ActionResult Slider()
        {
            var images = _slider.GetSliderImages();
            var imagesviewmodel = Mapper.Map<IEnumerable<HomeSlider>, IEnumerable<HomeSliderViewModel>>(images);
            return PartialView("_Slider", imagesviewmodel);

        }
        [ChildActionOnly]
        public ActionResult LookTechno(int cellId)
        {
            var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
            var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
            return PartialView("_LookTechno", cellSettingsViewModel);
        }
        [ChildActionOnly]
        public ActionResult OurServices(int cellId)
        {
            var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
            var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
            return PartialView("_OurServices", cellSettingsViewModel);
        }
        [ChildActionOnly]
        public ActionResult OurSolutions(int cellId)
        {
            var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
            var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
            return PartialView("_OurSolutions", cellSettingsViewModel);
        }
        [ChildActionOnly]
        public ActionResult AfterOurSolutions(int cellId)
        {
            var cellSettings = _cellSettingService.GetCellSettingsByCellId(cellId);
            var cellSettingsViewModel = Mapper.Map<CellSetting, CellSettingViewModel>(cellSettings);
            return PartialView("_AfterOurSolutions", cellSettingsViewModel);
        }
        [ChildActionOnly]
        public ActionResult OurProducts()
        {
            var images = _brandSliderService.GetAllSliderImages();
            var imagesviewmodel = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandsViewModel>>(images);
            return PartialView("_OurProducts", imagesviewmodel);
        }
    }
}