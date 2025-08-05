using System.Collections.Generic;

namespace AliasTopan.SimplyValidate
{
    public static class ValidatorExtensions
    {
        public static bool ValidateAnnotation(this object instance,
            out IReadOnlyCollection<AnnotationError> errors)
        {
            errors = AnnotationValidator.ValidateObject(instance);
            return errors.Count == 0;
        }
    }
}