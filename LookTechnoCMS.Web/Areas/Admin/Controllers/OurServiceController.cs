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
using LookTechnoCMS.Service.OurServicesService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class OurServiceController : BaseController
    {
        private readonly IOurServicesService _ourServicesService;

        public OurServiceController(IOurServicesService ourServicesService)
        {
            _ourServicesService = ourServicesService;
        }
        // GET: Admin/OurService
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(OurServicesViewModel ourServicesViewModel)
        {
            ourServicesViewModel.ShowHideImage = false;
            return View(ourServicesViewModel);
        }
        [HttpPost]
        public ActionResult Create(OurServicesViewModel ourServicesViewModel, IEnumerable<HttpPostedFileBase> files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (ourServicesViewModel != null && submit == "Save")
                {
                    ourServicesViewModel.DateCreated = DateTime.UtcNow;
                   ourServicesViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/OurServices/"), fileName);
                        ourServicesViewModel.Image = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var ourService = Mapper.Map<OurServicesViewModel, OurService>(ourServicesViewModel);

                    _ourServicesService.Add(ourService);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "OurService");
                }
                if (ourServicesViewModel != null && submit == "SaveAndContinue")
                {
                    ourServicesViewModel.DateCreated = DateTime.UtcNow;
                    ourServicesViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/OurServices/"), fileName);
                        ourServicesViewModel.Image = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var ourService = Mapper.Map<OurServicesViewModel, OurService>(ourServicesViewModel);

                    _ourServicesService.Add(ourService);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(ourServicesViewModel);
        }

        public ActionResult Edit(int id)
        {
            var service = _ourServicesService.GetServiceById(id);
            var ourServiceViewModel = Mapper.Map<OurService, OurServicesViewModel>(service);
            ourServiceViewModel.ShowHideImage = true;
            return View(ourServiceViewModel);
        }
        [HttpPost]
        public ActionResult Edit(OurServicesViewModel ourServicesViewModel, HttpPostedFileBase files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (ourServicesViewModel != null && submit == "Save")
                {
                    ourServicesViewModel.DateCreated = ourServicesViewModel.DateCreated;
                    ourServicesViewModel.DateModified = DateTime.UtcNow;

                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/OurServices/"), fileName);
                        files.SaveAs(path);
                        ourServicesViewModel.Image = fileName;
                    }
                    var service = Mapper.Map<OurServicesViewModel, OurService>(ourServicesViewModel);

                    _ourServicesService.Edit(service);
                    AddMessage(this, "", "Record has been modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "OurService");
                }
                if (ourServicesViewModel != null && submit == "SaveAndContinue")
                {
                    ourServicesViewModel.DateCreated = ourServicesViewModel.DateCreated;
                    ourServicesViewModel.DateModified = DateTime.UtcNow;
                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/OurServices/"), fileName);
                        files.SaveAs(path);
                        ourServicesViewModel.Image = fileName;
                    }
                    var service = Mapper.Map<OurServicesViewModel, OurService>(ourServicesViewModel);
                    _ourServicesService.Edit(service);

                    var id = service.Id;
                    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(ourServicesViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var service = _ourServicesService.GetServiceById(id);
            _ourServicesService.Delete(service);
            message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);



            return Json(new { ok = true, Message = message }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult GetServices([DataSourceRequest] DataSourceRequest request)
        {
            var services= _ourServicesService.GetAllServices();
            var ourServiceViewModel = Mapper.Map<IEnumerable<OurService>, IEnumerable<OurServicesViewModel>>(services);
            return Json(ourServiceViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}