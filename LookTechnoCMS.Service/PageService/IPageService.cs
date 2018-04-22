using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Data;

namespace LookTechnoCMS.Service.PageService
{
    public interface IPageService : IEntityService<Page>
    {
        Page GetById(int id);
        IEnumerable<Page> GetPages();
        Page GetPageByURL(string url);
    }
}
