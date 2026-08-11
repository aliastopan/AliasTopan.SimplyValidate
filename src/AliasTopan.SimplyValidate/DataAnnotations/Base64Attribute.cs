using System;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class Base64Attribute : ValidationAttribute
    {
        public Base64Attribute()
        {
            ErrorMessage = "The {0} field must be a valid Base64 string.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // Let [Required] handle nulls if needed
                return ValidationResult.Success;
            }

            if (value.GetType() != typeof(string))
            {
                return new ValidationResult(
                    $"{validationContext.MemberName} must be a string.");
            }

            try
            {
                Convert.FromBase64String((string)value);

                return ValidationResult.Success;
            }
            catch (FormatException)
            {
                return new ValidationResult(
                    FormatErrorMessage(validationContext.MemberName));
            }
        }
    }
}