using DemoCore.Services.Offer.API.Infrastructure.Middlewares;
using DemoCore.Services.Offer.API.Infrastructure.Middlewares.Failing;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class FailingMiddlewareAppBuilderExtensions
    {
        public static IApplicationBuilder UseFailingMiddleware(this IApplicationBuilder builder)
        {
            return UseFailingMiddleware(builder, null);
        }
        public static IApplicationBuilder UseFailingMiddleware(this IApplicationBuilder builder, Action<FailingOptions> action)
        {
            var options = new FailingOptions();
            action?.Invoke(options);
            builder.UseMiddleware<FailingMiddleware>(options);
            return builder;
        }
    }
}
