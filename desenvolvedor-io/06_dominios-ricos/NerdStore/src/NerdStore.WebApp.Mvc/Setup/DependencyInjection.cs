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
using NerdStore.Core.Messages.IntegrationEvents;
using NerdStore.Core.Messages.Notifications;
using NerdStore.Payments.AntiCorruption.Configurations;
using NerdStore.Payments.AntiCorruption.Facades;
using NerdStore.Payments.AntiCorruption.Gateways;
using NerdStore.Payments.AntiCorruption.Interfaces.PayPal;
using NerdStore.Payments.Business.Interfaces.Facades;
using NerdStore.Payments.Business.Interfaces.Repositories;
using NerdStore.Payments.Business.Interfaces.Services;
using NerdStore.Payments.Business.Services;
using NerdStore.Payments.Data.Context;
using NerdStore.Payments.Data.Repositories;
using NerdStore.Sales.Application.Commands;
using NerdStore.Sales.Application.Events;
using NerdStore.Sales.Application.Interfaces.Queries;
using NerdStore.Sales.Application.Queries;
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

            services.AddScoped<INotificationHandler<MinimumStockAmountEvent>, ProductEventHandler>();

            // Sales
            services.AddScoped<IRequestHandler<CreateOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<AddOrderItemCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderItemCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrderItemCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<ApplyVoucherCommand, bool>, OrderCommandHandler>();

            services.AddScoped<IOrderQueriesFacade, OrderQueriesFacade>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<SalesContext>();

            services.AddScoped<INotificationHandler<DraftOrderStartedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemAddedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderItemRemovedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<VoucherAppliedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderPaymentApprovedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderPaymentRefusedEvent>, OrderEventHandler>();

            // Payments
            services.AddScoped<ICreditCardPaymentFacade, CreditCardPaymentFacade>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<PaymentsContext>();

            // MediatR
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            return services;
        }
    }
}
