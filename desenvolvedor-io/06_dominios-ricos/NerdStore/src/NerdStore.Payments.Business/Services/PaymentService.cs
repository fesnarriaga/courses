using NerdStore.Core.DomainObjects.Dtos.Payment;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.IntegrationEvents;
using NerdStore.Core.Messages.Notifications;
using NerdStore.Payments.Business.Entities;
using NerdStore.Payments.Business.Enums;
using NerdStore.Payments.Business.Interfaces.Facades;
using NerdStore.Payments.Business.Interfaces.Repositories;
using NerdStore.Payments.Business.Interfaces.Services;
using NerdStore.Payments.Business.ViewModels;
using System.Threading.Tasks;

namespace NerdStore.Payments.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICreditCardPaymentFacade _creditCardPaymentFacade;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(
            IMediatorHandler mediatorHandler,
            ICreditCardPaymentFacade creditCardPaymentFacade,
            IPaymentRepository paymentRepository)
        {
            _mediatorHandler = mediatorHandler;
            _creditCardPaymentFacade = creditCardPaymentFacade;
            _paymentRepository = paymentRepository;
        }

        public async Task<Transaction> Pay(OrderPayment orderPayment)
        {
            var order = new Order
            {
                Id = orderPayment.OrderId,
                Total = orderPayment.Total
            };

            var payment = new Payment
            {
                OrderId = orderPayment.OrderId,
                Total = orderPayment.Total,
                CardName = orderPayment.CardName,
                CardNumber = orderPayment.CardNumber,
                CardExpiresAt = orderPayment.CardExpiresAt,
                CardCode = orderPayment.CardCode
            };

            var transaction = _creditCardPaymentFacade.Pay(order, payment);

            if (transaction.Status == TransactionStatus.Payed)
            {
                payment.AddEvent(new OrderPaymentApprovedEvent(
                    order.Id,
                    orderPayment.CustomerId,
                    transaction.PaymentId,
                    transaction.Id,
                    order.Total));

                _paymentRepository.Add(payment);
                _paymentRepository.AddTransaction(transaction);

                await _paymentRepository.UnitOfWork.Commit();
                return transaction;
            }

            await _mediatorHandler.PublishNotification(new DomainNotification("Payment", "Payment refused"));
            await _mediatorHandler.RaiseEvent(new OrderPaymentRefusedEvent(
                order.Id,
                orderPayment.CustomerId,
                transaction.PaymentId,
                transaction.Id,
                order.Total));

            return transaction;
        }
    }
}
