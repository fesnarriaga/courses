using NerdStore.Core.Messages;
using NerdStore.Sales.Application.Validations;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class CreateOrderCommand : Command
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Total { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiresAt { get; set; }
        public string CardCode { get; set; }

        public CreateOrderCommand(
            Guid customerId,
            Guid orderId,
            decimal total,
            string cardName,
            string cardNumber,
            string cardExpiresAt,
            string cardCode)
        {
            CustomerId = customerId;
            OrderId = orderId;
            Total = total;
            CardName = cardName;
            CardNumber = cardNumber;
            CardExpiresAt = cardExpiresAt;
            CardCode = cardCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}