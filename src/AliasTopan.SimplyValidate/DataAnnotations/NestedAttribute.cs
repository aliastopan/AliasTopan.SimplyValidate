using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NestedAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(value, null, null);

            bool isObjectValid = Validator.TryValidateObject(value, context, results, true);

            if (isObjectValid)
            {
                return new CompositeValidationResult($"The {validationContext.DisplayName} field is invalid.", results);
            }

            return ValidationResult.Success;
        }
    }
}