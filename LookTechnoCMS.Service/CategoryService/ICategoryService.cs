using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.CategoryService
{
    public interface ICategoryService : IEntityService<Category>
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
