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
using LookTechnoCMS.Service.BrandService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class BrandsSliderController : BaseController
    {
        private readonly IBrandSliderService _brandSliderService;

        public BrandsSliderController(IBrandSliderService brandSliderService)
        {
            _brandSliderService = brandSliderService;
        }

        // GET: Admin/BrandsSlider
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(BrandsViewModel brandsViewModel)
        {
            brandsViewModel.ShowHideImage = false;

            return View(brandsViewModel);
        }
        [HttpPost]
        public ActionResult Create(BrandsViewModel brandsViewModel, IEnumerable<HttpPostedFileBase> files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (brandsViewModel != null && submit == "Save")
                {
                    brandsViewModel.DateCreated = DateTime.UtcNow;
                    brandsViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/Brands/"), fileName);
                        brandsViewModel.Image = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var sliderImage = Mapper.Map<BrandsViewModel, Brand>(brandsViewModel);

                    _brandSliderService.Add(sliderImage);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "BrandsSlider");
                }
                if (brandsViewModel != null && submit == "SaveAndContinue")
                {
                    brandsViewModel.DateCreated = DateTime.UtcNow;
                    brandsViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/Brands/"), fileName);
                        brandsViewModel.Image = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var sliderImage = Mapper.Map<BrandsViewModel, Brand>(brandsViewModel);

                    _brandSliderService.Add(sliderImage);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(brandsViewModel);
        }
        public ActionResult Edit(int id)
        {
            var sliderImage = _brandSliderService.GetSliderImageById(id);
            var brandsViewModel = Mapper.Map<Brand, BrandsViewModel>(sliderImage);
            brandsViewModel.ShowHideImage = true;
            return View(brandsViewModel);
        }
        [HttpPost]
        public ActionResult Edit(BrandsViewModel brandsViewModel, HttpPostedFileBase files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (brandsViewModel != null && submit == "Save")
                {
                    brandsViewModel.DateCreated = brandsViewModel.DateCreated;
                    brandsViewModel.DateModified = DateTime.UtcNow;

                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/Brands/"), fileName);
                        files.SaveAs(path);
                        brandsViewModel.Image = fileName;
                    }
                    var sliderImage = Mapper.Map<BrandsViewModel, Brand>(brandsViewModel);
                    _brandSliderService.Edit(sliderImage);
                    AddMessage(this, "", "Record has been modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "BrandsSlider");
                }
                if (brandsViewModel != null && submit == "SaveAndContinue")
                {
                    brandsViewModel.DateCreated = brandsViewModel.DateCreated;
                    brandsViewModel.DateModified = DateTime.UtcNow;
                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/Brands/"), fileName);
                        files.SaveAs(path);
                        brandsViewModel.Image = fileName;
                    }
                    var sliderImage = Mapper.Map<BrandsViewModel, Brand>(brandsViewModel);
                    _brandSliderService.Edit(sliderImage);

                    var id = sliderImage.Id;
                    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(brandsViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var sliderImage = _brandSliderService.GetSliderImageById(id);
            _brandSliderService.Delete(sliderImage);
            message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);



            return Json(new { ok = true, Message = message }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult GetSliderImages([DataSourceRequest] DataSourceRequest request)
        {
            var sliderImage = _brandSliderService.GetAllSliderImages();
            var sliderImages = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandsViewModel>>(sliderImage);
            return Json(sliderImages.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}