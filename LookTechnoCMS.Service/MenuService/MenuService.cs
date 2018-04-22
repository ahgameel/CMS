using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.MenuService
{
    public class MenuService:EntityService<Menu>,IMenuService
    {
        readonly LookTechno _context;
        public MenuService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<Menu>();

        }

        public IEnumerable<Menu> GetMenuLinks()
        {
            var menuLinks = (from m in _context.Menus
                             join p in _context.Pages on m.PageId equals p.Id
                             select new
                             {
                                 m.Id,
                                 m.Name,
                                 m.NameAr,
                                 Url = p.NavigationUrl,
                                 m.PageId,
                                 m.ParentMenuId,
                                 m.Active,
                                 m.DateCreated


                             }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new Menu
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 NameAr=x.NameAr,
                                 Url = x.Url,
                                 PageId=x.PageId,
                                 ParentMenuId=x.ParentMenuId,
                                 Active=x.Active,



                             }).ToList();
            return menuLinks;
        }
        public Menu GetById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }

    }
}
