using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    internal sealed class CompositeValidationResult : ValidationResult
    {
        public IReadOnlyCollection<ValidationResult> Results { get; }

        public CompositeValidationResult(string errorMessage, IEnumerable<ValidationResult> results)
            : base(errorMessage)
        {
            Results = results.ToList().AsReadOnly();
        }
    }
}