using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CompleteApp.Api.Configurations
{
    public static class ElmahConfigurations
    {
        public static IServiceCollection AddElmahConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "da66bc2b08114e5ebc9420da61d1851b";
                o.LogId = new Guid("7201e0da-0106-4b7e-bed1-82b39333479f");
            });

            return services;
        }

        public static IApplicationBuilder UseElmahConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
