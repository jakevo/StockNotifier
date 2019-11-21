using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace StockNotifier.DepencyInjection
{
    public static class StockNotifierServiceProviderFactory
    {

        public static IServiceProvider Create()
        {
            var configBuilder = new ConfigurationBuilder();
            var assemPath = Path.GetDirectoryName(typeof(StockNotifierServiceProviderFactory).Assembly.Location);
            var path = Path.Combine(assemPath, "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var config = configBuilder.Build();


            var builder = new ContainerBuilder();
            builder.RegisterModule<StockNotifierEventsModule>();

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
