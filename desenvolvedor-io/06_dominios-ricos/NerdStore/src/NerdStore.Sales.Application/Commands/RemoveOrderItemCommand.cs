﻿using NerdStore.Core.Messages;
using NerdStore.Sales.Application.Validations;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class RemoveOrderItemCommand : Command
    {
        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }

        public RemoveOrderItemCommand(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrderItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}