using System;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
public sealed class NotZeroAttribute : ValidationAttribute
{
    public NotZeroAttribute()
    {
        ErrorMessage = "The {0} field cannot be zero.";
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

            if (number == 0m)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            return ValidationResult.Success;
        }
        catch
        {
            return new ValidationResult($"{validationContext.MemberName} must be a numeric type.");
        }
    }
}