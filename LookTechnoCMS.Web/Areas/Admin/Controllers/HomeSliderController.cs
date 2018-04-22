using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.SliderService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class HomeSliderController : BaseController
    {
        private readonly ISlider _slider;

        public HomeSliderController(ISlider slider)
        {
            _slider = slider;
        }
        // GET: Admin/HomeSlider
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(HomeSliderViewModel homeSliderViewModel)
        {
            homeSliderViewModel.ShowHideImage =false;
            return View(homeSliderViewModel);
        }
        [HttpPost]
        public ActionResult Create(HomeSliderViewModel homeSliderViewModel, IEnumerable<HttpPostedFileBase> files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (homeSliderViewModel != null && submit == "Save")
                {
                    homeSliderViewModel.DateCreated = DateTime.UtcNow;
                    homeSliderViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/Slider/"), fileName);
                        homeSliderViewModel.SlideImage = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var sliderImage = Mapper.Map<HomeSliderViewModel, HomeSlider>(homeSliderViewModel);

                    _slider.Add(sliderImage);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "HomeSlider");
                }
                if (homeSliderViewModel != null && submit == "SaveAndContinue")
                {
                    homeSliderViewModel.DateCreated = DateTime.UtcNow;
                    homeSliderViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/Slider/"), fileName);
                        homeSliderViewModel.SlideImage = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var sliderImage = Mapper.Map<HomeSliderViewModel, HomeSlider>(homeSliderViewModel);

                    _slider.Add(sliderImage);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(homeSliderViewModel);
        }

        public ActionResult Edit(int id)
        {
            var sliderImage= _slider.GetSliderImageById(id);
            var sliderviewmodel = Mapper.Map<HomeSlider, HomeSliderViewModel>(sliderImage);
            sliderviewmodel.ShowHideImage = true;
            return View(sliderviewmodel);
        }

        [HttpPost]
        public ActionResult Edit(HomeSliderViewModel homeSliderViewModel, HttpPostedFileBase files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (homeSliderViewModel != null && submit == "Save")
                {
                    homeSliderViewModel.DateCreated = homeSliderViewModel.DateCreated;
                    homeSliderViewModel.DateModified = DateTime.UtcNow;

                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/Slider/"), fileName);
                        files.SaveAs(path);
                        homeSliderViewModel.SlideImage = fileName;
                    }
                    var sliderImage = Mapper.Map<HomeSliderViewModel, HomeSlider>(homeSliderViewModel);
                    _slider.Edit(sliderImage);
                    AddMessage(this, "", "Record has been modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "HomeSlider");
                }
                if (homeSliderViewModel != null && submit == "SaveAndContinue")
                {
                    homeSliderViewModel.DateCreated = homeSliderViewModel.DateCreated;
                    homeSliderViewModel.DateModified = DateTime.UtcNow;
                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/Offer/"), fileName);
                        files.SaveAs(path);
                        homeSliderViewModel.SlideImage = fileName;
                    }
                    var sliderImage = Mapper.Map<HomeSliderViewModel, HomeSlider>(homeSliderViewModel);
                    _slider.Edit(sliderImage);

                    var id = sliderImage.Id;
                    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(homeSliderViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var sliderImage = _slider.GetSliderImageById(id);
            _slider.Delete(sliderImage);
            message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);

          

            return Json(new { ok = true, Message = message }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult GetSliderImages([DataSourceRequest] DataSourceRequest request)
        {
            var sliderImage = _slider.GetAllSliderImages();
            var sliderImages = Mapper.Map<IEnumerable<HomeSlider>, IEnumerable<HomeSliderViewModel>>(sliderImage);
            return Json(sliderImages.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}