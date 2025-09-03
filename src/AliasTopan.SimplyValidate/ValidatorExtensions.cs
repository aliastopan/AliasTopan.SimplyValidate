using System.Collections.Generic;

namespace AliasTopan.SimplyValidate
{
    public static class ValidatorExtensions
    {
        public static bool Validate(this object instance,
            out IReadOnlyCollection<ValidationError> errors)
        {
            errors = DataAnnotationsValidator.ValidateObject(instance);

            return errors.Count == 0;
        }

#if NET6_0_OR_GREATER
        public static bool ValidateWithLog(this object instance,
            out string jsonErrorLog, bool writeIndented = false)
        {
            IReadOnlyCollection<ValidationError> errors = DataAnnotationsValidator.ValidateObject(instance);
            jsonErrorLog = errors.ToJsonErrorLog(writeIndented);

            return errors.Count == 0;
        }
#endif
    }
}