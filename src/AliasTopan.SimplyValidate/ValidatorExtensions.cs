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

        public static bool ValidateWithLog(this object instance,
            out string jsonErrorLog)
        {
            IReadOnlyCollection<ValidationError> errors = AnnotationValidator.ValidateObject(instance);
            jsonErrorLog = errors.ToJsonErrorLog();

            return errors.Count == 0;
        }
    }
}