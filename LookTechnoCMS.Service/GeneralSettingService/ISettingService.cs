using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.GeneralSettingService
{
    public interface ISettingService:IEntityService<GeneralSetting>
    {
        GeneralSetting GetSettings();
    }
}
