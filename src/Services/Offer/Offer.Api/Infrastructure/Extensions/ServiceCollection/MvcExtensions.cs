using System;
using DemoCore.Services.Offer.API;
using DemoCore.Services.Offer.API.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Offer.API.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcExtension
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                options.Filters.Add(typeof(ValidateModelStateFilter));

            })
            .AddApiExplorer()
            .AddAuthorization()
            .AddJsonFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddControllersAsServices();

            return services;
        }


        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(InfrastructureConst.GeneralCorsPolicy,
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });


            return services;
        }
    }
}
