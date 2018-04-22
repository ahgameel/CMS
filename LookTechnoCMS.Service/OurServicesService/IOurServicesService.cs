using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.OurServicesService
{
    public interface IOurServicesService:IEntityService<OurService>
    {
        IEnumerable<OurService> GetAllServices();
       OurService GetServiceById(int id);
    }
}
