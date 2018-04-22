using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.BrandService
{
    public class BrandSliderService:EntityService<Brand>,IBrandSliderService
    {
        readonly LookTechno _context;
        public BrandSliderService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<Brand>();
        }

        public IEnumerable<Brand> GetAllSliderImages()
        {
            string url = Properties.Settings.Default.url;
            var sliderimages = (from h in _context.Brands

                                select new
                                {
                                    h.Id,
                                    h.BrandName,
                                    Image = url + "UploadFiles/Brands/" + h.Image,

                              
                                }).AsEnumerable().Select(x => new Brand
                                {
                                    Id = x.Id,
                                    BrandName = x.BrandName,
                                    Image = x.Image

                                  
                                }).ToList();
            return sliderimages;
        }

        public Brand GetSliderImageById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }
    }
}
