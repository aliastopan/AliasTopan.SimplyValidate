using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AliasTopan.SimplyValidate
{
    internal static class AnnotationValidator
    {
        public static List<AnnotationError> ValidateObject(object instance)
        {
            ValidationContext context = new ValidationContext(instance);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(instance, context, results,
                validateAllProperties: true);

            if (isValid)
            {
                return new List<AnnotationError>();
            }

            List<AnnotationError> errors = new List<AnnotationError>();

            foreach (var annotation in results)
            {
                if (annotation.MemberNames.Any())
                {
                    foreach (var memberName in annotation.MemberNames)
                    {
                        AnnotationError error = new AnnotationError(memberName, annotation.ErrorMessage);
                        errors.Add(error);
                    }
                }
                else
                {
                    AnnotationError error = new AnnotationError("Model", annotation.ErrorMessage);
                    errors.Add(error);
                }
            }

            return errors;
        }
    }
}