using CustomIdentity.Configurations;
using CustomIdentity.Extensions;
using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Text;

namespace CustomIdentity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (env.IsProduction())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILogger>((context) => Logger.Factory.Get());

            services.AddLogging(logging =>
            {
                logging.AddKissLog();
            });

            services.AddIdentityConfiguration(Configuration);

            services.AddAuthorizationConfiguration();

            services.AddDependencyInjectionConfiguration();

            services.AddControllersWithViews(options =>
            {
                // DI to resolve ILogger, see AddDependencyInjectionConfiguration
                options.Filters.Add(typeof(AuditFilter));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseKissLogMiddleware(options =>
            {
                ConfigureKissLog(options);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }

        private void ConfigureKissLog(IOptionsBuilder options)
        {
            // optional KissLog configuration
            options.Options
                .AppendExceptionDetails((Exception ex) =>
                {
                    StringBuilder sb = new StringBuilder();

                    if (ex is System.NullReferenceException nullRefException)
                    {
                        sb.AppendLine("Important: check for null references");
                    }

                    return sb.ToString();
                });

            // KissLog internal logs
            options.InternalLog = (message) =>
            {
                Debug.WriteLine(message);
            };

            // register logs output
            RegisterKissLogListeners(options);
        }

        private void RegisterKissLogListeners(IOptionsBuilder options)
        {
            // multiple listeners can be registered using options.Listeners.Add() method

            // register KissLog.net cloud listener
            options.Listeners.Add(new RequestLogsApiListener(new Application(
                    Configuration["KissLog.OrganizationId"],    //  "d6297399-b447-403a-83e0-0908bd32cfc3"
                    Configuration["KissLog.ApplicationId"])     //  "a0831c04-d277-4de0-9c52-fd74df5e0a42"
            )
            {
                ApiUrl = Configuration["KissLog.ApiUrl"]    //  "https://api.kisslog.net"
            });
        }
    }
}
