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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentity();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
