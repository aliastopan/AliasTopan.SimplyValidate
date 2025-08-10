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

            string[]? memberNames = new[]
            {
                validationContext.MemberName!
            };

            if (age < MinimumAge)
            {
                string errorMessage = FormatErrorMessage(validationContext.DisplayName);

                return new ValidationResult(errorMessage, memberNames);
            }

            if (dateOfBirth > today)
            {
                return new ValidationResult("Date of Birth cannot be in the future.", memberNames);
            }
        }

        return ValidationResult.Success!;
    }
}