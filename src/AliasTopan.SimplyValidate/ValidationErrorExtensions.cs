using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NET6_0_OR_GREATER
using System.Text.Json;
#endif

namespace AliasTopan.SimplyValidate
{
    public static class ValidationErrorExtensions
    {
        public static string GetErrorMessage(this IReadOnlyCollection<ValidationError> errors)
        {
            if (errors.Count == 0)
            {
                return "No validation errors.";
            }

            return errors.First().ErrorMessage;
        }

        public static string GetErrorMessageVerbose(this IReadOnlyCollection<ValidationError> errors)
        {
            if (errors.Count == 0)
            {
                return "No validation errors.";
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Validation failed with {errors.Count} error(s):");

            int i = 1;
            foreach (var error in errors)
            {
                builder.AppendLine($"  {i++}. [{error.MemberName}]: {error.ErrorMessage}");
            }

            return builder.ToString().TrimEnd();
        }

#if NET6_0_OR_GREATER
        public static string ToJsonErrorLog(this IReadOnlyCollection<ValidationError> errors, bool writeIndented = false)
        {
            if (errors == null || errors.Count == 0)
            {
                return writeIndented
                    ? "{\n  \"ValidationErrors\": []\n}"
                    : "{\"ValidationErrors\":[]}";
            }

            return JsonSerializer.Serialize(new
            {
                ValidationErrors = errors.Select(e => new
                {
                    e.MemberName,
                    e.ErrorMessage
                })
            }, new JsonSerializerOptions { WriteIndented = writeIndented });
        }
#endif
    }
}
