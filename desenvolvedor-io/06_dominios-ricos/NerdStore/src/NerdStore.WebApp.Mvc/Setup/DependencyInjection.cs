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
using NerdStore.Sales.Application.Commands;
using NerdStore.Sales.Data.Context;
using NerdStore.Sales.Data.Repositories;
using NerdStore.Sales.Domain.Interfaces.Repositories;

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

            // Sales
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<SalesContext>();

            services.AddScoped<IRequestHandler<AddOrderItemCommand, bool>, OrderCommandHandler>();

            // MediatR (Memory Bus)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}
