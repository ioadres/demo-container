using System;
using DemoCore.Services.Offer.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RedisExtension
    {
        public static IServiceCollection AddCustomRedis(this IServiceCollection services)
        {
            //By connecting here we are making sure that our service
            //cannot start until redis is ready. This might slow down startup,
            //but given that there is a delay on resolving the ip address
            //and then creating the connection it seems reasonable to move
            //that cost to startup instead of having the first request pay the
            //penalty.
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<OfferSetting>>().Value;
                var configurationRedis = ConfigurationOptions.Parse(settings.ConnectionString, true);

                configurationRedis.ResolveDns = true;

                return ConnectionMultiplexer.Connect(configurationRedis);
            });

            return services;
        }
    }
}
