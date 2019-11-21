using System;
using System.Net.Http;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using StockNotifier.Application;
using StockNotifier.Domain;
using StockNotifier.Infrastructure;

namespace StockNotifier.DepencyInjection
{
    public class StockNotifierEventsModule: Autofac.Module
    {
        public virtual void LoadInfractructure(ContainerBuilder builder)
        {
            builder.Register(c => new HttpClient()).SingleInstance();
     
        }

        protected override void Load(ContainerBuilder builder)
        {
            LoadInfractructure(builder);

           
            
            builder.Register(c => c.Resolve<IMessageSubscriber>());
            builder.Register(c => c.Resolve<IUseCase>());
        }
    }
}
