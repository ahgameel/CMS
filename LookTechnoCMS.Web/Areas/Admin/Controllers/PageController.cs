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
using LookTechnoCMS.Service.PageService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class PageController :  BaseController
    {
        private readonly IPageService _pageService;


        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }        
        // GET: Admin/Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(PageViewModel pageViewModel)
        {
            return View(pageViewModel);
        }
        [HttpPost]
        public ActionResult Create(PageViewModel pageViewModel,  string submit)
        {
            if (ModelState.IsValid)
            {
                if (pageViewModel != null && submit == "Save")
                {
                    pageViewModel.DateCreated = DateTime.UtcNow;
                    pageViewModel.DateModified = DateTime.UtcNow;

                    var page = Mapper.Map<PageViewModel, Page>(pageViewModel);
                    _pageService.Add(page);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Page");
                }
                if (pageViewModel != null && submit == "SaveAndContinue")
                {
                    pageViewModel.DateCreated = DateTime.UtcNow;
                    pageViewModel.DateModified = DateTime.UtcNow;

                    var page = Mapper.Map<PageViewModel, Page>(pageViewModel);
                    _pageService.Add(page);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(pageViewModel);
        }
        public ActionResult Edit(int id)
        {
            var page = _pageService.GetById(id);
            var pageviewmodel = Mapper.Map<Page, PageViewModel>(page);

            return View(pageviewmodel);
        }
        [HttpPost]
        public ActionResult Edit(PageViewModel pageViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (pageViewModel != null && submit == "Save")
                {
                    pageViewModel.DateCreated = pageViewModel.DateCreated;
                    pageViewModel.DateModified = DateTime.UtcNow;


                    var page = Mapper.Map<PageViewModel, Page>(pageViewModel);
                    _pageService.Edit(page);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Page");
                }
                if (pageViewModel != null && submit == "SaveAndContinue")
                {
                    pageViewModel.DateCreated = pageViewModel.DateCreated;
                    pageViewModel.DateModified = DateTime.UtcNow;

                    var page = Mapper.Map<PageViewModel, Page>(pageViewModel);
                    _pageService.Edit(page);

                    var id = page.Id;
                    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(pageViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var page = _pageService.GetById(id);

            if (page != null)
            {
                _pageService.Delete(page);
                message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);
                //if (page.m == 0)
                //{

                //    _serviceCategoryService.Delete(service);
                //    message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);

                //}
                //else
                //{
                //    message = AddMessage(this, "", "Can't Delete This Record  Because It Related To Order", MessageType.Warnning);
                //}



            }

            return Json(new { ok = true, Message = message }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetPages([DataSourceRequest] DataSourceRequest request)
        {
            var page = _pageService.GetPages();
            var pages = Mapper.Map<IEnumerable<Page>, IEnumerable<ListPageViewModel>>(page);
            return Json(pages.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}