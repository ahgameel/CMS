using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.OurSolutionsService;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Controllers
{
    public class SolutionController : Controller
    {
        private readonly IOurSolutionsService _ourSolutionsService;

        public SolutionController(IOurSolutionsService ourSolutionsService)
        {
            _ourSolutionsService = ourSolutionsService;
        }
        // GET: Solution
        public ActionResult Index()
        {
            var solutions = _ourSolutionsService.GetAllSolutions();
            var orSolutionsViewModel = Mapper.Map<IEnumerable<OurSolution>, IEnumerable<OurSolutionsViewModel>>(solutions);
            return View(orSolutionsViewModel);
        }

        public ActionResult TopSolutions()
        {
            var solutions = _ourSolutionsService.GetTopSolutions();
            var orSolutionsViewModel = Mapper.Map<IEnumerable<OurSolution>, IEnumerable<OurSolutionsViewModel>>(solutions);
            return PartialView("_TopSolutions", orSolutionsViewModel);
        }
    }
}