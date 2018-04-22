using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.CategoryService
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        readonly LookTechno _context;
        public CategoryService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<Category>();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = (from g in _context.Categories

                              select new
                              {
                                  g.Id,
                                  g.Name,
                                  g.NameAr,
                                  g.Description,
                                  g.DescriptionAr,
                                  g.DateCreated,
                                  g.DateModified


                              }).AsEnumerable().Select(x => new Category
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    NameAr=x.NameAr,
                                    Description=x.Description,
                                    DescriptionAr=x.DescriptionAr


                                }).ToList();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }
    }
}
