using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.PageService;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Controllers
{
    public class ContentPageController : Controller
    {
        private readonly IPageService _pageService;
        public ContentPageController(IPageService pageService)
        {
            _pageService = pageService;
        }
        // GET: ContentPage
        public ActionResult Index(String PageName)
        {

            var FindPageName = _pageService.GetPageByURL(PageName);
            var page = Mapper.Map<Page, PageViewModel>(FindPageName);




            if (FindPageName != null)
            {

                return View("Index", page);

            }
            if (FindPageName == null)
            {
                return RedirectToRoute(PageName);
            }

            return View("");

        }
    }
}