using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.CellService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class CellController :BaseController
    {
        private readonly ICellService _cellService;
        private readonly ICellSettingService _cellSettingService;
        public CellController(ICellService cellService ,ICellSettingService cellSettingService)
        {
            _cellService = cellService;
            _cellSettingService = cellSettingService;
        }
        // GET: Admin/Cell
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configure(int id)
        {
            switch (id)
            {
                case 1:
                    return RedirectToAction("OurSolutions", new { id = id });
                case 2:
                    return RedirectToAction("HomeAd", new { id = id });
                case 3:
                    return RedirectToAction("LatestNews", new { id = id });
                case 5:
                    return RedirectToAction("LookTechno", new { id = id });
                case 6:
                    return RedirectToAction("HowWeWork", new { id = id });
              case 7:
                    return RedirectToAction("Whyus", new { id = id });

              case 8:
                    return RedirectToAction("OurVision", new { id = id });

              case 9:
                    return RedirectToAction("OurMission", new { id = id });
              case 10:
                    return RedirectToAction("OurServices", new { id = id });
              case 12:
                    return RedirectToAction("AfterOurSolutions", new { id = id });
            }
            return View();
        }

        public ActionResult OurSolutions()
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(1);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult OurSolutions(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 1;
                    cellSettingViewModel.Id = 12;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 1;
                    cellSettingViewModel.Id = 12;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        public ActionResult LatestNews(CellSettingViewModel cellSettingViewModel)
        {
            cellSettingViewModel.ShowHideImage = true;
            return View(cellSettingViewModel);
        }
        public ActionResult HomeAd(CellSettingViewModel cellSettingViewModel)
        {
            cellSettingViewModel.ShowHideImage = true;
            return View(cellSettingViewModel);
        }
        public ActionResult LookTechno()
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(5);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult LookTechno(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 5;
                    cellSettingViewModel.Id = 1;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 5;
                    cellSettingViewModel.Id = 1;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        public ActionResult HowWeWork()
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(6);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult HowWeWork(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId =6;
                    cellSettingViewModel.Id = 5;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 6;
                    cellSettingViewModel.Id = 5;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        public ActionResult Whyus()
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(7);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult Whyus(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 7;
                    cellSettingViewModel.Id = 11;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 7;
                    cellSettingViewModel.Id = 11;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        public ActionResult OurVision()
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(8);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult OurVision(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 8;
                    cellSettingViewModel.Id = 7;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 8;
                    cellSettingViewModel.Id = 7;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        public ActionResult OurMission(CellSettingViewModel cellSettingViewModel)
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(9);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult OurMission(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 9;
                    cellSettingViewModel.Id = 8;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 9;
                    cellSettingViewModel.Id = 8;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        public ActionResult OurServices()
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(10);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult OurServices(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 10;
                    cellSettingViewModel.Id = 9;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 10;
                    cellSettingViewModel.Id = 9;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        public ActionResult AfterOurSolutions()
        {
            var cellsetting = _cellSettingService.GetCellSettingsByCellId(12);
            var cellsettings = Mapper.Map<CellSetting, CellSettingViewModel>(cellsetting);
            return View(cellsettings);
        }
        [HttpPost]
        public ActionResult AfterOurSolutions(CellSettingViewModel cellSettingViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellSettingViewModel != null && submit == "Save")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 12;
                    cellSettingViewModel.Id = 10;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);

                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Cell");
                }
                if (cellSettingViewModel != null && submit == "SaveAndContinue")
                {
                    cellSettingViewModel.DateCreated = DateTime.UtcNow;
                    cellSettingViewModel.DateModified = DateTime.UtcNow;
                    cellSettingViewModel.CellId = 12;
                    cellSettingViewModel.Id = 10;
                    var cellSetting = Mapper.Map<CellSettingViewModel, CellSetting>(cellSettingViewModel);
                    _cellSettingService.Edit(cellSetting);
                    AddMessage(this, "", "Record has Modified Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(cellSettingViewModel);
        }
        [HttpPost]
        public ActionResult Edit(CellViewModel cellViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (cellViewModel != null && submit == "Save")
                {
                    cellViewModel.DateCreated = DateTime.UtcNow;
                    cellViewModel.DateModified = DateTime.UtcNow;


                    //var page = Mapper.Map<PageViewModel, Page>(pageViewModel);
                    //_pageService.Edit(page);
                    //AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    //return RedirectToAction("Index", "Page");
                }
                //if (pageViewModel != null && submit == "SaveAndContinue")
                //{
                //    pageViewModel.DateCreated = DateTime.UtcNow;
                //    pageViewModel.DateModified = DateTime.UtcNow;

                //    var page = Mapper.Map<PageViewModel, Page>(pageViewModel);
                //    _pageService.Edit(page);

                //    var id = page.Id;
                //    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                //    return RedirectToAction("Edit", new { id = id });
                //}
            }
            return View(cellViewModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CellEditingInline([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<CellViewModel> cellViewModel)
        {
            if (cellViewModel != null && ModelState.IsValid)
            {

                foreach (var cell in cellViewModel)
                {
                    var cellexist = _cellService.GetCellById(cell.Id);
                    if (cellexist != null)
                    {
                        cellexist.ShowHide = cell.ShowHide;

                        _cellService.Edit(cellexist);
                    }
                }

            }
            AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
            return Json(new[] { cellViewModel }.ToDataSourceResult(request, ModelState));
        }
        public ActionResult GetCells([DataSourceRequest] DataSourceRequest request)
        {
            var cell = _cellService.GetCells();
            var cells = Mapper.Map<IEnumerable<Cell>, IEnumerable<CellViewModel>>(cell);
            return Json(cells.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCellSettings([DataSourceRequest] DataSourceRequest request,int cellId)
        {
            var cellsetting = _cellSettingService.GetSettingsByCellId(cellId);
            var cellsettings = Mapper.Map<IEnumerable<CellSetting>, IEnumerable<CellSettingViewModel>>(cellsetting);
            return Json(cellsettings.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}