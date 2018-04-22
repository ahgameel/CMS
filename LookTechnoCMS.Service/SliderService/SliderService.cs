using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.SliderService
{
   public  class SliderService:EntityService<HomeSlider>,ISlider
   {
       readonly LookTechno _context;
       public SliderService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<HomeSlider>();
        }

       public IEnumerable<HomeSlider> GetSliderImages()
       {              string url = Properties.Settings.Default.url;
           var sliderimages = (from h in _context.HomeSliders
               where h.IsActive == true
               select new
               {
                   h.Id,
                   h.SlideTitle,
                   Image = url + "UploadFiles/Slider/" + h.SlideImage,
               
                   h.IsActive
               }).AsEnumerable().Select(x => new HomeSlider
               {
                   Id = x.Id,
                   SlideTitle = x.SlideTitle,
                   SlideImage = x.Image,
                 
                   IsActive=x.IsActive
               }).ToList();
           return sliderimages;

       }

       public IEnumerable<HomeSlider> GetAllSliderImages()
       {
           string url = Properties.Settings.Default.url;
           var sliderimages = (from h in _context.HomeSliders
                             
                               select new
                               {
                                   h.Id,
                                   h.SlideTitle,
                                   Image = url + "UploadFiles/Slider/" + h.SlideImage,
                            
                                   h.IsActive
                               }).AsEnumerable().Select(x => new HomeSlider
                               {
                                   Id = x.Id,
                                   SlideTitle = x.SlideTitle,
                                   SlideImage = x.Image,
                             
                                   IsActive = x.IsActive
                               }).ToList();
           return sliderimages;
       }

       public HomeSlider GetSliderImageById(int id)
       {
           return Dbset.FirstOrDefault(x => x.Id == id);
       }
    }
}
