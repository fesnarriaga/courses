using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CompleteApp.Mvc.Extensions.Attributes
{
    // Server side behaviour
    public class CurrencyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var currency = Convert.ToDecimal(value, new CultureInfo("en-US"));
            }
            catch (Exception)
            {
                return new ValidationResult("Currency is not valid");
            }

            return ValidationResult.Success;
        }
    }

    // Client side behaviour
    public class CurrencyAttributeAdapter : AttributeAdapterBase<CurrencyAttribute>
    {
        public CurrencyAttributeAdapter(CurrencyAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return "Currency is not valid";
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-currency", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-number", GetErrorMessage(context));
        }
    }

    // Validation provider
    public class CurrencyValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _provider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is CurrencyAttribute currencyAttribute)
            {
                return new CurrencyAttributeAdapter(currencyAttribute, stringLocalizer);
            }

            return _provider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
