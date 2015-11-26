using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using NServiceBus;
using WesternDevs.RockyDonut.Api.App_Start;

namespace WesternDevs.RockyDonut.Api
{
    public class WebApiApplication : NinjectHttpApplication
    {
        private BusConfiguration _busConfiguration;
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BusConfigurator.Start(_busConfiguration);
            
        }

        protected override IKernel CreateKernel()
        {
            _busConfiguration = BusConfigurator.Configure();
            return NinjectConfigurator.CreateKernel(_busConfiguration);
        }
    }
}
