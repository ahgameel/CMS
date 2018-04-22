using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Data;


namespace LookTechnoCMS.Service.CellService
{
    public interface ICellSettingService : IEntityService<CellSetting>
    {
        IEnumerable<CellSetting> GetSettingsByCellId(int id);
        CellSetting GetSettingById(int id);
        CellSetting GetCellSettingsByCellId(int id);
    }
}
