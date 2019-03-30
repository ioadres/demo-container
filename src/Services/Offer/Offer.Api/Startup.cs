using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.Services.Offer.API.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using StackExchange.Redis;

using Autofac.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Http;
using Autofac;
using DemoCore.Services.Offer.API.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using DemoCore.Services.Offer.API.Infrastructure.Middlewares.Failing;

namespace DemoCore.Services.Offer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomMvc(Configuration)
                .AddCustomCors()
                .AddCustomConfiguration(Configuration)
                .AddCustomAuthentication(Configuration)
                .AddCustomSwagger(Configuration)
                .AddCustomHealthCheck(Configuration)
                .AddCustomDependency()
                .AddCustomRedis();

            //### Autofac builder
            var container = new ContainerBuilder();
            container.Populate(services);


            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            app
                .UseCustomHealth()
                .UseStaticFiles()
                .UseCors("CorsPolicy")
                .UseAuthentication()
                .UseMvcWithDefaultRoute()
                .UseCustomSwagger(Configuration);

        }       
    }

}
