using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.CellService
{
   public  class CellSettingService:EntityService<CellSetting>,ICellSettingService
   {
       readonly LookTechno _context;
       string url = Properties.Settings.Default.url;
       public CellSettingService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<CellSetting>();

        }

       public IEnumerable<CellSetting> GetSettingsByCellId(int id)
       {
           var cells = (from c in _context.CellSettings

                        select new
                        {
                            c.Id,
                            c.Title,
                            c.TitleAr,
                            c.Link,
                            Image = url + "UploadFiles/Cells/" + c.Image,
                            c.Description,
                            c.DescriptionAr,
                            c.CellId,
                            c.DateCreated,
                            c.DateModified


                        }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new CellSetting
                        {
                            Id = x.Id,
                            Title = x.Title,
                            TitleAr =x.TitleAr,
                            Link=x.Link,
                            Image=x.Image,
                            Description=x.Description,
                            DescriptionAr=x.DescriptionAr,
                            CellId=x.CellId,





                        }).ToList();
           return cells;
       }

       public CellSetting GetSettingById(int id)
       {
           return Dbset.FirstOrDefault(x => x.Id == id);
       }

       public CellSetting GetCellSettingsByCellId(int id)
       {
           var cells = (from c in _context.CellSettings
                         where c.CellId==id
                        select new
                        {
                            c.Id,
                            c.Title,
                            c.TitleAr,
                            c.Link,
                            Image = url + "UploadFiles/Cells/" + c.Image,
                            c.Description,
                            c.DescriptionAr,
                            c.CellId,
                            c.DateCreated,
                            c.DateModified


                        }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new CellSetting
                        {
                            Id = x.Id,
                            Title = x.Title,
                            TitleAr = x.TitleAr,
                            Link = x.Link,
                            Image = x.Image,
                            Description = x.Description,
                            DescriptionAr = x.DescriptionAr,
                            CellId = x.CellId,





                        }).FirstOrDefault();
           return cells;
       }
   }
}
