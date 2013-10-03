using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace prj666vc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // AutoMapper definitions

            // Program - FROM app domain model classes
            Mapper.CreateMap<Models.Note, ViewModels.NotePublic>();
            Mapper.CreateMap<Models.Note, ViewModels.NoteBase>();
            Mapper.CreateMap<Models.Note, ViewModels.NoteFull>();

            // Program - TO app domain model classes
            Mapper.CreateMap<ViewModels.NotePublic, Models.Note>();
            Mapper.CreateMap<ViewModels.NoteBase, Models.Note>();
            Mapper.CreateMap<ViewModels.NoteFull, Models.Note>();
        }
    }
}