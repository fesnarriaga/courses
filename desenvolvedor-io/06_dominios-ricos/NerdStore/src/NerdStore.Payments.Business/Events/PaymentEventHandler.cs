using MediatR;
using NerdStore.Core.DomainObjects.Dtos.Payment;
using NerdStore.Core.Messages.IntegrationEvents;
using NerdStore.Payments.Business.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Payments.Business.Events
{
    public class PaymentEventHandler : INotificationHandler<StockDecreaseSucceedEvent>
    {
        private readonly IPaymentService _paymentService;

        public PaymentEventHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task Handle(StockDecreaseSucceedEvent notification, CancellationToken cancellationToken)
        {
            var orderPayment = new OrderPayment
            {
                CustomerId = notification.CustomerId,
                OrderId = notification.OrderId,
                Total = notification.Total,
                CardName = notification.CardName,
                CardNumber = notification.CardNumber,
                CardExpiresAt = notification.CardExpiresAt,
                CardCode = notification.CardCode
            };

            await _paymentService.Pay(orderPayment);
        }
    }
}
