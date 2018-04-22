using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.OurSolutionsService
{
    public class OurSolutionsService : EntityService<OurSolution>, IOurSolutionsService
    {
        readonly LookTechno _context;
        public OurSolutionsService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<OurSolution>();
        }

        public IEnumerable<OurSolution> GetAllSolutions()
        {
            string url = Properties.Settings.Default.url;
            var solutions = (from o in _context.OurSolutions

                            select new
                            {
                                o.Id,
                                o.Name,
                                o.NameAr,
                                o.Description,
                                o.DescriptionAr,
                                Image = url + "UploadFiles/OurSolutions/" + o.Image,
                                o.ShowInHomePage,
                                o.DateCreated,
                                o.DateModified


                            }).AsEnumerable().Select(x => new OurSolution
                            {
                                Id = x.Id,
                                Name = x.Name,
                                NameAr = x.NameAr,
                                Description = x.Description,
                                DescriptionAr = x.DescriptionAr,
                                Image = x.Image,
                                ShowInHomePage =x.ShowInHomePage



                            }).ToList();
            return solutions;
        }

        public OurSolution GetSolutionById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OurSolution> GetTopSolutions()
        {
            string url = Properties.Settings.Default.url;
            var solutions = (from o in _context.OurSolutions
                where o.ShowInHomePage == true 
           
                             select new
                             {
                                 o.Id,
                                 o.Name,
                                 o.NameAr,
                                 o.Description,
                                 o.DescriptionAr,
                                 Image = url + "UploadFiles/OurSolutions/" + o.Image,
                                 o.ShowInHomePage,
                                 o.DateCreated,
                                 o.DateModified


                             }).AsEnumerable().Select(x => new OurSolution
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 NameAr = x.NameAr,
                                 Description = x.Description,
                                 DescriptionAr = x.DescriptionAr,
                                 Image = x.Image,
                                 ShowInHomePage = x.ShowInHomePage



                             }).ToList().Take(4);
            return solutions;
        }
    }
}
