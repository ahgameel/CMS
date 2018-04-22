using AutoMapper;

using LookTechnoCMS.Data;
using LookTechnoCMS.Web.Areas.Admin.Models;
using LookTechnoCMS.Web.Models;


namespace LookTechnoCMS.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
          CreateMap<ApplicationUser, UserIndexViewModel>();
          CreateMap<ApplicationRole, RoleIndexViewModel>();
           
            CreateMap<Page, PageViewModel>();
            CreateMap<Page, ListPageViewModel>();
            CreateMap<Menu, MenuViewModel>();
            CreateMap<Menu, ListMenuViewModel>();
            CreateMap<Cell, CellViewModel>();
            CreateMap<CellSetting, CellSettingViewModel>();
            CreateMap<HomeSlider, HomeSliderViewModel>();
            CreateMap<Brand,BrandsViewModel>();
            CreateMap<Contatctu, ContactUsViewModel>();
            CreateMap<NewsletterSubscriber, SubscribersViewModel>();
            CreateMap<GeneralSetting, SettingViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<OurService, OurServicesViewModel>();
            CreateMap<OurSolution, OurSolutionsViewModel>();
        }
    }
}