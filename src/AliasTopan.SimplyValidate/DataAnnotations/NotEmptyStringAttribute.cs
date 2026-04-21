using System;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class NotEmptyStringAttribute : ValidationAttribute
    {
        public NotEmptyStringAttribute()
        {
            ErrorMessage = "The {0} field cannot be null, empty, or whitespace.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            if (!(value is string str) || string.IsNullOrWhiteSpace(str))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            return ValidationResult.Success;
        }
    }
}
