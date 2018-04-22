using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.OurSolutionsService
{
    public interface IOurSolutionsService : IEntityService<OurSolution>
    {
        IEnumerable<OurSolution> GetAllSolutions();
        OurSolution GetSolutionById(int id);
        IEnumerable<OurSolution> GetTopSolutions();
    }
}
