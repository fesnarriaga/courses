using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteApp.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                //options.SwaggerDoc("v1",
                //    new OpenApiInfo
                //    {
                //        Title = "Complete App API",
                //        Version = "v1",
                //        Description = "Awesome Complete App API",
                //        TermsOfService = new Uri("https://www.google.com"),
                //        Contact = new OpenApiContact
                //        {
                //            Name = "Felipe Esnarriaga",
                //            Email = "f_esnarriaga@yahoo.com.br"
                //        },
                //        License = new OpenApiLicense
                //        {
                //            Name = "Apache 2.0",
                //            Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                //        }
                //    });

                //options.DocInclusionPredicate((docName, apiDesc) =>
                //{
                //    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                //    var versions = methodInfo.DeclaringType
                //        .GetCustomAttributes(true)
                //        .OfType<ApiVersionAttribute>()
                //        .SelectMany(attr => attr.Versions);

                //    return versions.Any(v => $"v{v.ToString()}" == docName);
                //});

                //// Prevents naming collision
                //// Payment.Product, Catalog.Product
                //options.CustomSchemaIds((type) => type.FullName);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    var version = description.GroupName;
                    options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"Complete App API {version}");
                }
            });

            return app;
        }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                return;

            foreach (var parameter in operation.Parameters)
            {
                var description =
                    context.ApiDescription.ParameterDescriptions.First(x => x.Name == parameter.Name);

                var routeInfo = description.RouteInfo;

                operation.Deprecated = OpenApiOperation.DeprecatedDefault;

                parameter.Description ??= description.ModelMetadata?.Description;

                if (routeInfo == null)
                    continue;

                if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
                    parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue?.ToString());

                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription versionDescription)
        {
            var info = new OpenApiInfo
            {
                Title = "Complete App API",
                Version = versionDescription.ApiVersion.ToString(),
                Description = "Awesome Complete App API",
                TermsOfService = new Uri("https://www.google.com"),
                Contact = new OpenApiContact
                {
                    Name = "Felipe Esnarriaga",
                    Email = "f_esnarriaga@yahoo.com.br"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                }
            };

            if (versionDescription.IsDeprecated)
                info.Description += " This is a deprecated version!";

            return info;
        }
    }

    public class SwaggerAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.User.Identity == null)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            if (httpContext.Request.Path.StartsWithSegments("/swagger") &&
                !httpContext.User.Identity.IsAuthenticated)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next.Invoke(httpContext);
        }
    }
}
