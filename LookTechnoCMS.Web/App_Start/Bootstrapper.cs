//using HomeCinema.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LookTechnoCMS.Web.Mappings;


namespace LookTechnoCMS.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac
           // AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            AutofacConfig.Configure();
            //Configure AutoMapper
           AutoMapperConfiguration.Configure();
        }
    }

   
}