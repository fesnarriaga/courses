using CompleteApp.Api.Extensions.Auth;
using CompleteApp.Business.Interfaces.Auth;
using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Notifications;
using CompleteApp.Business.Services;
using CompleteApp.Data.Context;
using CompleteApp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CompleteApp.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<INotificator, Notificator>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AppUser>();

            return services;
        }
    }
}
