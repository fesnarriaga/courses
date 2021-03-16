using CustomIdentity.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CustomIdentity.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //services.AddTransient<IAnyThing, AnyThing>();
            services.AddScoped<AuditFilter>();

            return services;
        }
    }
}
