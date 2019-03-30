using System;
using DemoCore.Services.Offer.API;
using DemoCore.Services.Offer.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddCustomDependency(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IBasketRepository, RedisBasketRepository>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
