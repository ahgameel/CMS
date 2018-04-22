using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LookTechnoCMS.Data;
using LookTechnoCMS.Service.CategoryService;
using LookTechnoCMS.Service.ProductService;
using LookTechnoCMS.Web.Models;

namespace LookTechnoCMS.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public ProductsController(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        // GET: ProductCatalog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
          var productviewmodel = Mapper.Map<Product, ProductViewModel>(product);
          return View(productviewmodel);
        }

        public ActionResult Categories()
        {
            var categories = _categoryService.GetAllCategories();
            var categoryviewmodel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return PartialView("_Categories", categoryviewmodel);
        }
  
        public ActionResult ProducList(int categoryId)
        {
            var products = _productService.GetProductsByCategoryId(categoryId);
            var productviewmodel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            return PartialView("_ProductList",productviewmodel);
       
        }
    }
}