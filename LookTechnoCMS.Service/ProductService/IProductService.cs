using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.ProductService
{
    public interface IProductService:IEntityService<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}
