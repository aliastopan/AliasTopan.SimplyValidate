using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace AliasTopan.SimplyValidate
{
    public static class ValidationErrorExtensions
    {
        public static string GetMessage(this IReadOnlyCollection<ValidationError> errors)
        {
            if (errors.Count == 0)
            {
                return "No validation errors.";
            }

            return errors.First().ErrorMessage;
        }

        public static string GetMessageVerbose(this IReadOnlyCollection<ValidationError> errors)
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

        public static string ToJsonErrorLog(this IReadOnlyCollection<ValidationError> errors)
        {
            if (errors == null || errors.Count == 0)
            {
                return "{\"ValidationErrors\":[]}";
            }

            return JsonSerializer.Serialize(new
            {
                ValidationErrors = errors.Select(e => new
                {
                    e.MemberName,
                    e.ErrorMessage
                })
            }, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
