using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus;
using NServiceBus.Features;
using WesternDevs.RockyDonut.Contracts;

namespace WesternDevs.RockyDonut.Api.App_Start
{
    public class BusConfigurator
    {
        private static IStartableBus _startableBus;
        public static BusConfiguration Configure()
        {
            var configuration = new BusConfiguration();
            
            configuration.UseTransport<AzureStorageQueueTransport>();
            configuration.UsePersistence<AzureStoragePersistence>();
            configuration.Conventions().DefiningEventsAs(x => x.Name != null && x.Namespace.Equals(typeof(SlackMessage).Namespace));
            configuration.DisableFeature<SecondLevelRetries>();
            configuration.DisableFeature<Sagas>();
            configuration.DisableFeature<TimeoutManager>();
            
            return configuration;
        }

        public static void Start(BusConfiguration configuration)
        {
            _startableBus = Bus.Create(configuration);
            _startableBus.Start();
        }
    }
}