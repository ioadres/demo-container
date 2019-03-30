using System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Microsoft.AspNetCore.Builder
{
    public static class HealthExtensions
    {
        public static IApplicationBuilder UseCustomHealth(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });

            return app;
        }
    }
}
