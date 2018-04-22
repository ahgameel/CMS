using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Reflection;
using System.Web;
using LookTechnoCMS.Service.BrandService;
using LookTechnoCMS.Service.CategoryService;
using LookTechnoCMS.Service.OurServicesService;
using LookTechnoCMS.Service.OurSolutionsService;
using LookTechnoCMS.Service.ProductService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Service.CellService;
using LookTechnoCMS.Service.ContactusService;
using LookTechnoCMS.Service.GeneralSettingService;
using LookTechnoCMS.Service.MenuService;
using LookTechnoCMS.Service.NewsletterSubscriberService;
using LookTechnoCMS.Service.PageService;
using LookTechnoCMS.Service.SecurityService;
using LookTechnoCMS.Service.SliderService;



namespace LookTechnoCMS.Web.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

        

            builder.RegisterType<UserManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<RoleManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<SignInManager>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<LookTechno>()


                 .InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>()
                   .InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<SliderService>().As<ISlider>().InstancePerLifetimeScope();
            builder.RegisterType<BrandSliderService>().As<IBrandSliderService>().InstancePerLifetimeScope();
            builder.RegisterType<PageService>().As<IPageService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<CellService>().As<ICellService>().InstancePerLifetimeScope();
            builder.RegisterType<CellSettingService>().As<ICellSettingService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ContactUsService>().As<IContactUsService>().InstancePerLifetimeScope();
            builder.RegisterType<SubscribersService>().As<ISubscribersService>().InstancePerLifetimeScope();
            builder.RegisterType<SettingService>().As<ISettingService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<OurServicesService>().As<IOurServicesService>().InstancePerLifetimeScope();
            builder.RegisterType<OurSolutionsService>().As<IOurSolutionsService>().InstancePerLifetimeScope();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<LookTechno>())).AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => new RoleStore<ApplicationRole>(c.Resolve<LookTechno>())).AsImplementedInterfaces().InstancePerRequest();
  
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));






        }

    }
}