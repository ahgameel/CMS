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
using LookTechnoCMS.Service.MenuService;
using LookTechnoCMS.Service.PageService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;
using Menu = LookTechnoCMS.Data.Menu;


namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;
        private readonly IPageService _pageService;

        public MenuController(IMenuService menuService, IPageService pageService)
        {
            _menuService = menuService;
            _pageService = pageService;
        }
        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(MenuViewModel menuViewModel)
        {
            return View(menuViewModel);
        }

        [HttpPost]
        public ActionResult Create(MenuViewModel menuViewModel, string submit)
        {

            if (ModelState.IsValid)
            {
                if (menuViewModel != null && submit == "Save")
                {
                    menuViewModel.DateCreated = DateTime.UtcNow;
                    menuViewModel.DateModified = DateTime.UtcNow;

                    var menuLink = Mapper.Map<MenuViewModel, Menu>(menuViewModel);
                    _menuService.Add(menuLink);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Menu");
                }
                if (menuViewModel != null && submit == "SaveAndContinue")
                {
                    menuViewModel.DateCreated = DateTime.UtcNow;
                    menuViewModel.DateModified = DateTime.UtcNow;

                    var menuLink = Mapper.Map<MenuViewModel, Menu>(menuViewModel);
                    _menuService.Add(menuLink);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(menuViewModel);
        }
             [HttpPost]
        public ActionResult Edit(MenuViewModel menuViewModel, string submit)
        {

            if (ModelState.IsValid)
            {
                if (menuViewModel != null && submit == "Save")
                {
                    menuViewModel.DateCreated = DateTime.UtcNow;
                    menuViewModel.DateModified = menuViewModel.DateCreated;

                    var menuLink = Mapper.Map<MenuViewModel, Menu>(menuViewModel);
                    _menuService.Edit(menuLink);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Menu");
                }
                if (menuViewModel != null && submit == "SaveAndContinue")
                {
                    menuViewModel.DateCreated = DateTime.UtcNow;
                    menuViewModel.DateModified = menuViewModel.DateCreated;

                    var menuLink = Mapper.Map<MenuViewModel, Menu>(menuViewModel);
                    _menuService.Edit(menuLink);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(menuViewModel);
        }
   
        public ActionResult Edit(int id)
        {
            var menuLink = _menuService.GetById(id);
            var menuViewModel = Mapper.Map<Menu, MenuViewModel>(menuLink);
            return View(menuViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var menuLink = _menuService.GetById(id);

            if (menuLink != null)
            {

                if (menuLink.Page.Menus.Count == 0)
                {

                    _menuService.Delete(menuLink);
                    message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);

                }
                else
                {
                    message = AddMessage(this, "", "Can't Delete This Record  Because It Related to another item", MessageType.Error);
                    return Json(new { ok = true, Message = message }, JsonRequestBehavior.DenyGet);
                }



            }

            return Json(new { ok = true, Message = message }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult GetMenuLinks([DataSourceRequest] DataSourceRequest request)
        {
            var menu = _menuService.GetMenuLinks();
            var menuLinks = Mapper.Map<IEnumerable<LookTechnoCMS.Data.Menu>, IEnumerable<ListMenuViewModel>>(menu);
            return Json(menuLinks.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPages()
        {
            var pages = _pageService.GetPages();
            var pagelist = Mapper.Map<IEnumerable<Page>, IEnumerable<ListPageViewModel>>(pages);
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetParentMenuLink()
        {
            var links = _menuService.GetMenuLinks();
            var linklist = Mapper.Map<IEnumerable<Menu>, IEnumerable<ListMenuViewModel>>(links);
            return Json(linklist, JsonRequestBehavior.AllowGet);
        }
    }
}