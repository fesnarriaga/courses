using CompleteApp.Business.Interfaces;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Data.Context;
using CompleteApp.Data.Repositories;
using CompleteApp.Mvc.Extensions.Attributes;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace CompleteApp.Mvc.Configurations
{
    public static class DependencyInjectionConfigurations
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<CompleteAppContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddSingleton<IValidationAttributeAdapterProvider, CurrencyValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
