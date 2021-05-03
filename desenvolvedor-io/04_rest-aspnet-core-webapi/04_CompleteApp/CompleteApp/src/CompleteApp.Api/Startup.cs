using CompleteApp.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompleteApp.Api
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
            services.AddEntityFramework(Configuration);

            services.AddIdentity(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddElmahConfiguration();

            services.AddApi();

            services.AddDependencies();

            services.AddSwaggerConfig();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwaggerConfig(provider);

            app.UseElmahConfiguration();

            app.UseApi(env);
        }
    }
}
