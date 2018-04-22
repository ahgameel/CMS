using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Data;

namespace LookTechnoCMS.Service.CellService
{
    public interface ICellService:IEntityService<Cell>
    {
        IEnumerable<Cell> GetCells();
        Cell GetCellById(int id);
    }
}
