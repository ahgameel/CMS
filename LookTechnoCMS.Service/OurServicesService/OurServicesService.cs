using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.OurServicesService
{
    public class OurServicesService : EntityService<OurService>, IOurServicesService
    {
        readonly LookTechno _context;
        public OurServicesService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<OurService>();
        }

        public IEnumerable<OurService> GetAllServices()
        {
            string url = Properties.Settings.Default.url;
            var services = (from o in _context.OurServices

                            select new
                            {
                                o.Id,
                                o.Name,
                                o.NameAr,
                                o.Description,
                                o.DescriptionAr,
                                Image = url + "UploadFiles/OurServices/" + o.Image,
                                o.ShowInHomePage,
                                o.DateCreated,
                                o.DateModified


                            }).AsEnumerable().Select(x => new OurService
                            {
                                Id = x.Id,
                                Name = x.Name,
                                NameAr = x.NameAr,
                                Description=x.Description,
                                DescriptionAr=x.DescriptionAr,
                                Image = x.Image,
                                ShowInHomePage =x.ShowInHomePage



                            }).ToList();
            return services;
        }

        public OurService GetServiceById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }
    }
}
