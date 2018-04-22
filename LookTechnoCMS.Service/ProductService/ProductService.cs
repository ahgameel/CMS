using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.ProductService
{
   public  class ProductService:EntityService<Product>,IProductService
   {
       readonly LookTechno _context;
       public ProductService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<Product>();
        }

       public IEnumerable<Product> GetAllProducts()
       {
           string url = Properties.Settings.Default.url;
           var products = (from p in _context.Products

                             select new
                             {
                                 p.Id,
                                 p.Name,
                                 p.NameAr,
                                 p.CategoryId,
                                 ImagePath = url + "UploadFiles/Products/" + p.ImagePath,      
                                 p.DateCreated,
                                 p.DateModified


                             }).AsEnumerable().Select(x => new Product
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 NameAr = x.NameAr,
                                 CategoryId=x.CategoryId,
                                 ImagePath=x.ImagePath
                               


                             }).ToList();
           return products;
       }

       public Product GetProductById(int id)
       {
           return Dbset.FirstOrDefault(x => x.Id == id);
       }

       public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
       {
           string url = Properties.Settings.Default.url;
           var products = (from p in _context.Products
                           where p.CategoryId==categoryId && p.Active==true
                           select new
                           {
                               p.Id,
                               p.Name,
                               p.NameAr,
                               p.Description,
                               p.DescriptionAr,
                               p.CategoryId,
                               ImagePath = url + "UploadFiles/Products/" + p.ImagePath,
                               p.DateCreated,
                               p.DateModified


                           }).AsEnumerable().Select(x => new Product
                           {
                               Id = x.Id,
                               Name = x.Name,
                               NameAr = x.NameAr,
                               Description=x.Description,
                               DescriptionAr=x.DescriptionAr,
                               CategoryId = x.CategoryId,
                               ImagePath = x.ImagePath



                           }).ToList();
           return products;
       }
   }
}
