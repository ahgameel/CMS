using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.PageService
{
    public class PageService : EntityService<Page>, IPageService
    {
        readonly LookTechno _context;

        public PageService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<Page>();

        }

        public IEnumerable<Page> GetPages()
        {
            var page = (from c in _context.Pages

                           select new
                           {
                               c.Id,
                               c.Name,
                              c.NameAr,
                               c.DateCreated


                           }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new Page
                           {
                               Id = x.Id,
                               Name = x.Name,
                               NameAr=x.NameAr


                           }).ToList();





            return page.ToList();
        }
        public Page GetPageByURL(string url)
        {
            var page = (from c in _context.Pages
                        where c.NavigationUrl == url
                        select new
                        {
                            c.Id,
                            c.Name,
                            c.NameAr,
                            c.Body,
                            c.BodyAr,
                            c.MetaDescription,
                            c.MetaKeywords,
                            c.MetaTitle,
                            c.DateCreated


                        }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new Page
                        {
                            Id = x.Id,
                            Name = x.Name,
                            NameAr=x.NameAr,
                            Body = x.Body,
                            BodyAr=x.BodyAr,
                            MetaDescription = x.MetaDescription,
                            MetaTitle = x.MetaTitle,
                            MetaKeywords = x.MetaKeywords


                        }).FirstOrDefault();





            return page;
        }

        public Page GetById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }
    }
}
