using System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerExtensions
    {
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, string pathBase)
        {
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Offer.API V1");
                   c.OAuthClientId("offerswaggerui");
                   c.OAuthAppName("Offer Swagger UI");
               });

            return app;
        }
    }
}
