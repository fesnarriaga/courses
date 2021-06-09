using System;
using System.Linq;
using Xunit;

namespace MyStore.Sales.Domain.Tests
{
    public class VoucherTests
    {
        [Fact(DisplayName = "Value Voucher Valid")]
        [Trait("Category", "Sales Voucher")]
        public void Voucher_ValueVoucherValid_ShouldBeValid()
        {
            // Arrange
            var voucher = new Voucher(
                "15-OFF",
                VoucherDiscountType.Cash,
                15,
                null,
                1,
                DateTime.Now.AddDays(2),
                true,
                false);

            // Act
            var result = voucher.Applicable();

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Value Voucher invalid")]
        [Trait("Category", "Sales Voucher")]
        public void Voucher_ValueVoucherInvalid_ShouldBeInvalid()
        {
            // Arrange
            var voucher = new Voucher(
                "",
                VoucherDiscountType.Cash,
                null,
                null,
                0,
                DateTime.Now.AddDays(-2),
                false,
                true);

            // Act
            var result = voucher.Applicable();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(6, result.Errors.Count);
            Assert.Contains(VoucherApplicableValidation.CodeErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.CashDiscountErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.QuantityErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.ExpirationDateErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.ActiveErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.UsedErrorMessage, result.Errors.Select(x => x.ErrorMessage));
        }

        [Fact(DisplayName = "Percent Voucher Valid")]
        [Trait("Category", "Sales Voucher")]
        public void Voucher_PercentVoucherValid_ShouldBeValid()
        {
            // Arrange
            var voucher = new Voucher(
                "15-OFF",
                VoucherDiscountType.Percent,
                null,
                15,
                1,
                DateTime.Now.AddDays(2),
                true,
                false);

            // Act
            var result = voucher.Applicable();

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Percent Voucher invalid")]
        [Trait("Category", "Sales Voucher")]
        public void Voucher_PercentVoucherInvalid_ShouldBeInvalid()
        {
            // Arrange
            var voucher = new Voucher(
                "",
                VoucherDiscountType.Percent,
                null,
                null,
                0,
                DateTime.Now.AddDays(-2),
                false,
                true);

            // Act
            var result = voucher.Applicable();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(6, result.Errors.Count);
            Assert.Contains(VoucherApplicableValidation.CodeErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.PercentDiscountErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.QuantityErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.ExpirationDateErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.ActiveErrorMessage, result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.UsedErrorMessage, result.Errors.Select(x => x.ErrorMessage));
        }
    }
}
