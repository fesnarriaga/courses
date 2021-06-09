using MediatR;
using NerdStore.Catalog.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Events
{
    public class MinimumStockAmountEventHandler : INotificationHandler<MinimumStockAmountEvent>
    {
        private readonly IProductRepository _productRepository;

        public MinimumStockAmountEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(MinimumStockAmountEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(notification.AggregateId);

            // Do something
        }
    }
}
