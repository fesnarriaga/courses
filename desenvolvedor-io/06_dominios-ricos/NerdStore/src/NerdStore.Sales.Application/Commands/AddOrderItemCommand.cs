using NerdStore.Core.Messages;
using NerdStore.Sales.Application.Validations;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class AddOrderItemCommand : Command
    {
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }

        public AddOrderItemCommand(
            string productName,
            int quantity,
            decimal price,
            Guid customerId,
            Guid productId)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            CustomerId = customerId;
            ProductId = productId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddOrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
