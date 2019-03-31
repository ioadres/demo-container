using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Offer.API.Infrastructure.AutofacModules;
using Offer.API.Infrastructure;
using Microsoft.Extensions.Options;

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
                .AddCustomMvc()
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

            container.RegisterModule(new ApplicationModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<OfferSetting> settings)
        {
            var pathBase = Configuration["PATH_BASE"]; // Deploy path 
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            app
                .UseCustomHealth(settings.Value)
                .UseStaticFiles()
                .UseCors(InfrastructureConst.GeneralCorsPolicy)
                .UseAuthentication()
                .UseMvcWithDefaultRoute()
                .UseCustomSwagger(pathBase);

        }       
    }

}
