using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Catalog.Application.Services;
using NerdStore.Catalog.Data.Context;
using NerdStore.Catalog.Data.Repositories;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Repositories;
using NerdStore.Catalog.Domain.Services;
using NerdStore.Catalog.Service.Services;
using NerdStore.Core.Mediator;

namespace NerdStore.WebApp.Mvc.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Catalog
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CatalogContext>();
            services.AddScoped<INotificationHandler<MinimumStockAmountEvent>, MinimumStockAmountEventHandler>();

            // MediatR (Memory Bus)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}
