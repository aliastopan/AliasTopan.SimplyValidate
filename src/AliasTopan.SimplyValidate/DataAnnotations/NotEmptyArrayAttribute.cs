using System;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class NotEmptyArrayAttribute : ValidationAttribute
    {
        public NotEmptyArrayAttribute()
        {
            ErrorMessage = "The {0} field cannot be null or empty.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is Array array) || array.Length == 0)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            return ValidationResult.Success;
        }
    }
}
