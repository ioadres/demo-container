using System;
using DemoCore.Services.Offer.API;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationExtension
    {
       public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OfferSetting>(configuration);
            return services;
        }
    }
}
