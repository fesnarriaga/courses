using NerdStore.Core.Messages;
using NerdStore.Sales.Application.Validations;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class ApplyVoucherCommand : Command
    {
        public Guid CustomerId { get; private set; }
        public string VoucherCode { get; private set; }

        public ApplyVoucherCommand(Guid customerId, string voucherCode)
        {
            CustomerId = customerId;
            VoucherCode = voucherCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new ApplyVoucherValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
