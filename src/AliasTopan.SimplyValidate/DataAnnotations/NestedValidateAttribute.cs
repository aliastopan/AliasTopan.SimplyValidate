using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NestedValidateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var results = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);

            bool isNestedObjectValid = Validator.TryValidateObject(value, context, results, true);

            if (isNestedObjectValid)
            {
                return ValidationResult.Success;
            }

            string errorMessage = FormatErrorMessage(validationContext.DisplayName);

            return new ValidationResult(errorMessage);
        }
    }
}