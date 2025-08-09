using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliasTopan.SimplyValidate.Abstractions
{
    public abstract class AggregateAnnotationError
    {
        public IReadOnlyCollection<AnnotationError> AnnotationErrors { get; }

        public virtual string Message => GetFirstErrorMessage();
        public virtual string MessageVerbose => FormatAllErrorMessages();

        protected AggregateAnnotationError(IReadOnlyCollection<AnnotationError> errors)
        {
            AnnotationErrors = errors ?? System.Array.Empty<AnnotationError>();
        }

        private string GetFirstErrorMessage()
        {
            if (AnnotationErrors.Count == 0)
            {
                return "An unspecified validation error occurred.";
            }

            return AnnotationErrors.First().ErrorMessage;
        }

        private string FormatAllErrorMessages()
        {
            if (AnnotationErrors.Count == 0)
            {
                return "No annotation errors were found.";
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Validation failed with {AnnotationErrors.Count} error(s):");

            int i = 1;
            foreach (var error in AnnotationErrors)
            {
                builder.AppendLine($"  {i++}. [{error.MemberName}]: {error.ErrorMessage}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}