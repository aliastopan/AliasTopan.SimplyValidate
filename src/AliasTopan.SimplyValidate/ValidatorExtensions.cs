using System.Collections.Generic;

namespace AliasTopan.SimplyValidate
{
    public static class ValidatorExtensions
    {
        public static bool Validate(this object instance,
            out IReadOnlyCollection<ValidationError> errors)
        {
            errors = AnnotationValidator.ValidateObject(instance);
            return errors.Count == 0;
        }
    }
}