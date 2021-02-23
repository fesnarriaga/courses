using IdentityExample.Areas.Identity.Data;
using IdentityExample.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityExample
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                //.AddDefaultUI()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete"));

                // With helper
                options.AddPolicy("Create", policy =>
                    policy.Requirements.Add(new CustomAuthorizationRequirement("Create")));

                options.AddPolicy("Read", policy =>
                    policy.Requirements.Add(new CustomAuthorizationRequirement("Read")));

                options.AddPolicy("Update", policy =>
                    policy.Requirements.Add(new CustomAuthorizationRequirement("Update")));

                options.AddPolicy("Delete", policy =>
                    policy.Requirements.Add(new CustomAuthorizationRequirement("Delete")));
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
