using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.GeneralSettingService
{
   public class SettingService:EntityService<GeneralSetting>,ISettingService
   {
        readonly LookTechno _context;
       string url = Properties.Settings.Default.url;
       public SettingService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<GeneralSetting>();

        }

       public GeneralSetting GetSettings()
       {
           return Dbset.FirstOrDefault();
       }
   }
}
