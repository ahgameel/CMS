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
using LookTechnoCMS.Service.CategoryService;
using LookTechnoCMS.Service.ProductService;
using LookTechnoCMS.Web.Controllers;
using LookTechnoCMS.Web.Infrastructure;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            PopulateCategory();
            return View();
        }
        public ActionResult Create(ProductViewModel productViewModel)
        {
            productViewModel.ShowHideImage = false;
            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel, IEnumerable<HttpPostedFileBase> files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel != null && submit == "Save")
                {
                    productViewModel.DateCreated = DateTime.UtcNow;
                    productViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/Products/"), fileName);
                        productViewModel.ImagePath = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var product = Mapper.Map<ProductViewModel, Product>(productViewModel);

                    _productService.Add(product);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Product");
                }
                if (productViewModel != null && submit == "SaveAndContinue")
                {
                    productViewModel.DateCreated = DateTime.UtcNow;
                    productViewModel.DateModified = DateTime.UtcNow;
                    foreach (var file in files)
                    {
                        //Some browsers send file names with a full path. You only care about the file name.
                        var fileName = Path.GetFileName(file.FileName);
                        var destinationPath = Path.Combine(Server.MapPath("~/UploadFiles/Products/"), fileName);
                        productViewModel.ImagePath = fileName;
                        file.SaveAs(destinationPath);
                    }
                    var product = Mapper.Map<ProductViewModel, Product>(productViewModel);

                    _productService.Add(product);
                    AddMessage(this, "", "Record has Added Successfully", MessageType.Success);
                    ModelState.Clear();
                    return View();
                }
            }
            return View(productViewModel);
        }

        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            productViewModel.ShowHideImage = true;
            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel, HttpPostedFileBase files, string submit)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel != null && submit == "Save")
                {
                    productViewModel.DateCreated = productViewModel.DateCreated;
                    productViewModel.DateModified = DateTime.UtcNow;

                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/Products/"), fileName);
                        files.SaveAs(path);
                        productViewModel.ImagePath = fileName;
                    }
                    var product = Mapper.Map<ProductViewModel, Product>(productViewModel);

                    _productService.Edit(product);
                    AddMessage(this, "", "Record has been modified Successfully", MessageType.Success);
                    return RedirectToAction("Index", "Product");
                }
                if (productViewModel != null && submit == "SaveAndContinue")
                {
                    productViewModel.DateCreated = productViewModel.DateCreated;
                    productViewModel.DateModified = DateTime.UtcNow;
                    if (files != null)
                    {
                        // Delete exiting file
                        // System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images/Category/"), serviceViewModel.Image));
                        // Save new file
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadFiles/Products/"), fileName);
                        files.SaveAs(path);
                        productViewModel.ImagePath = fileName;
                    }
                    var product = Mapper.Map<ProductViewModel, Product>(productViewModel);
                    _productService.Edit(product);

                    var id = product.Id;
                    AddMessage(this, "", "Record has been modified successfully", MessageType.Success);
                    return RedirectToAction("Edit", new { id = id });
                }
            }
            return View(productViewModel);
        }
        public ActionResult Delete(int id)
        {
            object message = null;
            var product = _productService.GetProductById(id);
            _productService.Delete(product);
            message = AddMessage(this, "", "Record has been deleted successfully", MessageType.Success);



            return Json(new { ok = true, Message = message }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult GetProducts([DataSourceRequest] DataSourceRequest request)
        {
            var products = _productService.GetAllProducts();
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            return Json(productViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private void PopulateCategory()
        {
            var categories = _categoryService.GetAllCategories();


            var categorylist = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            ViewData["categories"] = categorylist;
        }
        public JsonResult GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            var categorylist = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return Json(categorylist, JsonRequestBehavior.AllowGet);
        }
    }
}