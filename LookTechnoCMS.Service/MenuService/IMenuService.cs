using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Data;

namespace LookTechnoCMS.Service.MenuService
{
    public interface IMenuService : IEntityService<Menu>
    {
        IEnumerable<Menu> GetMenuLinks();
        Menu GetById(int id);
    }
}
