using FluentValidation;
using System;

namespace MyStore.Sales.Domain
{
    public class VoucherApplicableValidation : AbstractValidator<Voucher>
    {
        public static string CodeErrorMessage = "Invalid Code";
        public static string CashDiscountErrorMessage = "Cash Discount must be greater than 0";
        public static string PercentDiscountErrorMessage = "Percent Discount must be greater than 0";
        public static string QuantityErrorMessage = "Quantity already used";
        public static string ExpirationDateErrorMessage = "Voucher expired";
        public static string ActiveErrorMessage = "Voucher is not active";
        public static string UsedErrorMessage = "Voucher already used";

        public VoucherApplicableValidation()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage(CodeErrorMessage);

            When(x => x.DiscountType == VoucherDiscountType.Cash, () =>
            {
                RuleFor(x => x.CashDiscount)
                    .NotNull().WithMessage(CashDiscountErrorMessage)
                    .GreaterThan(0).WithMessage(CashDiscountErrorMessage);
            });

            When(x => x.DiscountType == VoucherDiscountType.Percent, () =>
            {
                RuleFor(x => x.PercentDiscount)
                    .NotNull().WithMessage(PercentDiscountErrorMessage)
                    .GreaterThan(0).WithMessage(PercentDiscountErrorMessage);
            });

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage(QuantityErrorMessage);

            RuleFor(x => x.ExpirationDate)
                .Must(ExpirationDateGraterThanToday).WithMessage(ExpirationDateErrorMessage);

            RuleFor(x => x.Active)
                .Equal(true).WithMessage(ActiveErrorMessage);

            RuleFor(x => x.Used)
                .Equal(false).WithMessage(UsedErrorMessage);
        }

        protected static bool ExpirationDateGraterThanToday(DateTime expirationDate)
        {
            return expirationDate >= DateTime.Now;
        }
    }
}
