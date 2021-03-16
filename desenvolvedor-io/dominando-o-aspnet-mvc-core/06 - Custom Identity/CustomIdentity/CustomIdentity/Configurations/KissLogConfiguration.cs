using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CustomIdentity.Configurations
{
    public static class KissLogConfiguration
    {
        public static IServiceCollection AddKissLoggerConfiguration(this IServiceCollection services, IHttpContextAccessor context)
        {
            //services.AddScoped<ILogger>((context) => Logger.Factory.Get());
            services.AddScoped<ILogger>()

            return services;
        }

        public static IApplicationBuilder UseKissLoggerConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseKissLogMiddleware(options => ConfigureKissLog(options, configuration));

            return app;
        }

        private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            var sb = new StringBuilder();

            options.Options
                .AppendExceptionDetails(ex =>
                {
                    if (ex is NullReferenceException)
                    {
                        sb.AppendLine("Important: check for null references");
                    }

                    return sb.ToString();
                });

            options.InternalLog = (message) =>
            {
                Debug.WriteLine(message);
            };

            RegisterKissLogListeners(options, configuration);
        }

        private static void RegisterKissLogListeners(IOptionsBuilder options, IConfiguration configuration)
        {
            options.Listeners.Add(
                new RequestLogsApiListener(
                    new Application(
                        configuration["KissLog.OrganizationId"],
                        configuration["KissLog.ApplicationId"]))
                {
                    ApiUrl = configuration["KissLog.ApiUrl"]
                });
        }
    }
}
