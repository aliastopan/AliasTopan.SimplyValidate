using System;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class PositiveIntegerAttribute : ValidationAttribute
    {
        public PositiveIntegerAttribute()
        {
            ErrorMessage = "The {0} field must be a positive integer.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // Let [Required] handle nulls if needed
                return ValidationResult.Success;
            }

            try
            {
                decimal number = Convert.ToDecimal(value);

                if (number <= 0m || number != decimal.Truncate(number))
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.MemberName));
                }

                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult(
                    $"{validationContext.MemberName} must be an integer type.");
            }
        }
    }
}