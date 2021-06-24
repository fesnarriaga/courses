using NerdStore.Core.Messages;
using NerdStore.Sales.Application.Validations;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class UpdateOrderItemCommand : Command
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public UpdateOrderItemCommand(Guid customerId, Guid productId, int quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}