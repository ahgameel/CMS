using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Data;

namespace LookTechnoCMS.Service.SliderService
{
    public interface ISlider:IEntityService<HomeSlider>
    {
        IEnumerable<HomeSlider> GetSliderImages();

        IEnumerable<HomeSlider> GetAllSliderImages();
        HomeSlider GetSliderImageById(int id);
    }
}
