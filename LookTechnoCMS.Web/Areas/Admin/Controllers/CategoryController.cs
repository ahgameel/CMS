using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.CategoryService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            return View(categoryViewModel);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (categoryViewModel != null && submit == "Save")
                {
                    categoryViewModel.DateCreated = DateTime.UtcNow;
                    categoryViewModel.DateModified = DateTime.UtcNow;

                    var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                    _categoryService.Add(category);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Category");
                }
                if (categoryViewModel != null && submit == "SaveAndContinue")
                {
                    categoryViewModel.DateCreated = DateTime.UtcNow;
                    categoryViewModel.DateModified = DateTime.UtcNow;

                    var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                    _categoryService.Add(category);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(categoryViewModel);
        }
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            var categoryviewmodel = Mapper.Map<Category, CategoryViewModel>(category);

            return View(categoryviewmodel);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel, string submit)
        {
            if (ModelState.IsValid)
            {
                if (categoryViewModel != null && submit == "Save")
                {
                    categoryViewModel.DateCreated = categoryViewModel.DateCreated;
                    categoryViewModel.DateModified = DateTime.UtcNow;

                    var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                    _categoryService.Edit(category);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Category");
                }
                if (categoryViewModel != null && submit == "SaveAndContinue")
                {
                    categoryViewModel.DateCreated = categoryViewModel.DateCreated;
                    categoryViewModel.DateModified = DateTime.UtcNow;

                    var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                    _categoryService.Edit(category);

                    var id = category.Id;
                    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(categoryViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var category = _categoryService.GetCategoryById(id);
            if (category != null)
            {
                if (category.Products.Count == 0)
                {
                    _categoryService.Delete(category);
                    message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);
                }
                else
                {
                    message = AddMessage(this, "", "Can't Delete This Record  Because It Related To Order", MessageType.Warning);
                }
            }


            return Json(new { ok = true, Message = message },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCategories([DataSourceRequest] DataSourceRequest request)
        {
            var categories = _categoryService.GetAllCategories();
            var categoryViewModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return Json(categoryViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}