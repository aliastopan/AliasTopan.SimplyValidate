using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.ManualTest.DataAnnotations;

public class AgeRequirementAttribute : ValidationAttribute
{
    public int MinimumAge { get; set; }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateOnly dateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth > today.AddYears(-age))
            {
                age--;
            }

            if (age < MinimumAge)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            if (dateOfBirth > today)
            {
                return new ValidationResult("Date of Birth cannot be in the future.");
            }
        }

        return ValidationResult.Success!;
    }
}