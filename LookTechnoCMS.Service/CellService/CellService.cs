using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.CellService
{
    public class CellService : EntityService<Cell>, ICellService
    {
        readonly LookTechno _context;
        public CellService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<Cell>();

        }

        public IEnumerable<Cell> GetCells()
        {
            var cells = (from c in _context.Cells

                             select new
                             {
                                 c.Id,
                                 c.CellTitle,
                                c.CellTitleAr,
                                 c.DateCreated,
                                 c.ShowHide


                             }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new Cell
                             {
                                 Id = x.Id,
                                 CellTitle = x.CellTitle,
                                 CellTitleAr=x.CellTitleAr,
                                 ShowHide=x.ShowHide
                              



                             }).ToList();
            return cells;
        }

        public Cell GetCellById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }
    }
}
