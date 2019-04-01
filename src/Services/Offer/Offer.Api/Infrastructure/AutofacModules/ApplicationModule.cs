using System;
using Autofac;
using Offer.API.Module.Offer;

namespace Offer.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<OfferRedisRepository>().As<IOfferRepository>().InstancePerLifetimeScope();
        }
    }
}
