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
using LookTechnoCMS.Service.OurSolutionsService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class OurSolutionsController : BaseController
    {
        private readonly IOurSolutionsService _ourSolutionsService;

        public OurSolutionsController(IOurSolutionsService ourSolutionsService)
        {
            _ourSolutionsService = ourSolutionsService;
        }
        // GET: Admin/OurSolutions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(OurSolutionsViewModel ourSolutionsViewModel)
        {
            ourSolutionsViewModel.ShowHideImage = false;
            return View(ourSolutionsViewModel);
        }
        [HttpPost]
        public ActionResult Create(OurSolutionsViewModel ourSolutionsViewModel, IEnumerable<HttpPostedFileBase> files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (ourSolutionsViewModel != null && submit == "Save")
                {
                    ourSolutionsViewModel.DateCreated = DateTime.UtcNow;
                    ourSolutionsViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/OurSolutions/"), fileName);
                        ourSolutionsViewModel.Image = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var ourSolution = Mapper.Map<OurSolutionsViewModel, OurSolution>(ourSolutionsViewModel);

                    _ourSolutionsService.Add(ourSolution);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "OurSolutions");
                }
                if (ourSolutionsViewModel != null && submit == "SaveAndContinue")
                {
                    ourSolutionsViewModel.DateCreated = DateTime.UtcNow;
                    ourSolutionsViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/OurSolutions/"), fileName);
                        ourSolutionsViewModel.Image = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var ourSolution = Mapper.Map<OurSolutionsViewModel, OurSolution>(ourSolutionsViewModel);

                    _ourSolutionsService.Add(ourSolution);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(ourSolutionsViewModel);
        }
        public ActionResult Edit(int id)
        {
            var solution = _ourSolutionsService.GetSolutionById(id);
            var ourSolutionViewModel = Mapper.Map<OurSolution, OurSolutionsViewModel>(solution);
            ourSolutionViewModel.ShowHideImage =true;
            return View(ourSolutionViewModel);
        }
        [HttpPost]
        public ActionResult Edit(OurSolutionsViewModel ourSolutionsViewModel, HttpPostedFileBase files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (ourSolutionsViewModel != null && submit == "Save")
                {
                    ourSolutionsViewModel.DateCreated = ourSolutionsViewModel.DateCreated;
                    ourSolutionsViewModel.DateModified = DateTime.UtcNow;

                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/OurSolutions/"), fileName);
                        files.SaveAs(path);
                        ourSolutionsViewModel.Image = fileName;
                    }
                    var solution = Mapper.Map<OurSolutionsViewModel, OurSolution>(ourSolutionsViewModel);

                    _ourSolutionsService.Edit(solution);
                    AddMessage(this, "", "Record has been modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "OurSolutions");
                }
                if (ourSolutionsViewModel != null && submit == "SaveAndContinue")
                {
                    ourSolutionsViewModel.DateCreated = ourSolutionsViewModel.DateCreated;
                    ourSolutionsViewModel.DateModified = DateTime.UtcNow;
                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/OurSolutions/"), fileName);
                        files.SaveAs(path);
                        ourSolutionsViewModel.Image = fileName;
                    }
                    var solution = Mapper.Map<OurSolutionsViewModel, OurSolution>(ourSolutionsViewModel);
                    _ourSolutionsService.Edit(solution);

                    var id = solution.Id;
                    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(ourSolutionsViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var solution = _ourSolutionsService.GetSolutionById(id);
            _ourSolutionsService.Delete(solution);
            message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);



            return Json(new { ok = true, Message = message }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult GetSolutions([DataSourceRequest] DataSourceRequest request)
        {
            var solutions = _ourSolutionsService.GetAllSolutions();
            var ourSolutionViewModel = Mapper.Map<IEnumerable<OurSolution>, IEnumerable<OurSolutionsViewModel>>(solutions);
            return Json(ourSolutionViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}