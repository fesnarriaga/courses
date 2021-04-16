using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CompleteApp.Mvc.Configurations
{
    public static class I18NConfigurations
    {
        public static IServiceCollection AddI18NConfigurations(this IServiceCollection services)
        {
            return services;
        }

        public static IApplicationBuilder UseI18NConfigurations(this IApplicationBuilder app)
        {
            var supportedCultures = new[] { "en-US" };

            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            return app;
        }
    }
}
