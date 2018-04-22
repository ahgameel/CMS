using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Data;


namespace LookTechnoCMS.Service.BrandService
{
    public interface IBrandSliderService:IEntityService<Brand>
    {
        IEnumerable<Brand> GetAllSliderImages();
        Brand GetSliderImageById(int id);
    }
}
