using CompleteApp.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompleteApp.Api.Configurations
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddHealthChecks()
            //    .AddDbContextCheck<AppDbContext>();

            //services
            //    .AddHealthChecksUI(options =>
            //    {
            //        options.SetEvaluationTimeInSeconds(15);
            //        options.MaximumHistoryEntriesPerEndpoint(60);
            //        options.SetApiMaxActiveRequests(1);

            //        options.AddHealthCheckEndpoint("API", "/healthz");
            //    })
            //    .AddInMemoryStorage();

            //services.AddHealthChecks()
            //    .AddDbContextCheck<AppDbContext>();

            //services.AddHealthChecksUI();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Development",
            //        builder =>
            //            builder
            //                .AllowAnyOrigin()
            //                .AllowAnyMethod()
            //                .AllowAnyHeader());


            //    options.AddPolicy("Production",
            //        builder =>
            //            builder
            //                .WithMethods("GET")
            //                .WithOrigins("http://desenvolvedor.io")
            //                .SetIsOriginAllowedToAllowWildcardSubdomains()
            //                //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
            //                .AllowAnyHeader());
            //});

            return services;
        }

        public static IApplicationBuilder UseApi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseCors("Development");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentity();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();

                //endpoints.MapHealthChecks("/hc");

                //endpoints.MapHealthChecks("/hc-details",
                //    new HealthCheckOptions
                //    {
                //        ResponseWriter = async (context, report) =>
                //        {
                //            var result = JsonSerializer.Serialize(
                //                new
                //                {
                //                    status = report.Status.ToString(),
                //                    monitors = report.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                //                });
                //            context.Response.ContentType = MediaTypeNames.Application.Json;
                //            await context.Response.WriteAsync(result);
                //        }
                //    }
                //);

                //endpoints.MapHealthChecks("/healthz", new HealthCheckOptions
                //{
                //    Predicate = _ => true,
                //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});

                //endpoints.MapHealthChecksUI();

                endpoints.MapControllers();

                //endpoints.MapHealthChecks("/api/hc", new HealthCheckOptions()
                //{
                //    Predicate = _ => true,
                //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});

                //endpoints.MapHealthChecksUI(options =>
                //{
                //    options.UIPath = "/api/hc-ui";
                //    options.ResourcesPath = "/api/hc-ui-resources";

                //    options.UseRelativeApiPath = false;
                //    options.UseRelativeResourcesPath = false;
                //    options.UseRelativeWebhookPath = false;
                //});
            });

            return app;
        }
    }
}
