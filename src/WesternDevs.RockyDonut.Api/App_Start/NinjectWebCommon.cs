using System;
using Ninject;
using NServiceBus;
using WesternDevs.RockyDonut.Api.Infrastructure;

namespace WesternDevs.RockyDonut.Api.App_Start
{
    public static class NinjectConfigurator 
    {
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel(BusConfiguration busConfiguration)
        {
            var kernel = new StandardKernel();
            try
            {               
                RegisterServices(kernel, busConfiguration);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel, BusConfiguration busConfiguration)
        {
            kernel.Bind<IConfiguration>().To<Configuration>();
            busConfiguration.UseContainer<NinjectBuilder>(x => x.ExistingKernel(kernel));
        }        
    }
}
