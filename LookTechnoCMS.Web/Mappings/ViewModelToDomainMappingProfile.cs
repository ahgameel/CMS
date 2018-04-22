using AutoMapper;

using LookTechnoCMS.Web.Areas.Admin.Models;
using LookTechnoCMS.Data;
using LookTechnoCMS.Web.Models;


namespace LookTechnoCMS.Web.Mappings
{

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<UserIndexViewModel, ApplicationUser>();
            CreateMap<EditUserViewModel, ApplicationUser>();
         
            CreateMap<PageViewModel, Page>();
            CreateMap<ListPageViewModel, Page>();
            CreateMap<MenuViewModel, Menu>();
            CreateMap<ListMenuViewModel, Menu>();
            CreateMap<CellViewModel, Cell>();
            CreateMap<CellSettingViewModel, CellSetting>();
            CreateMap<HomeSliderViewModel, HomeSlider>();
            CreateMap<BrandsViewModel, Brand>();
            CreateMap<ContactUsViewModel, Contatctu>();
            CreateMap<SubscribersViewModel, NewsletterSubscriber>();
            CreateMap<SettingViewModel, GeneralSetting>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<OurServicesViewModel, OurService>();
            CreateMap<OurSolutionsViewModel, OurSolution>();
        }
    }
}