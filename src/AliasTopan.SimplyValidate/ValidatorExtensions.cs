using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AliasTopan.SimplyValidate
{
    public static class ValidatorExtensions
    {
        public static bool ValidateAnnotation(this object instance,
            out IReadOnlyCollection<AnnotationError> errors)
        {
            ValidationContext context = new ValidationContext(instance);
            List<ValidationResult> results = new List<ValidationResult>();
            bool validateAll = true;

            bool isValid = Validator.TryValidateObject(instance, context, results, validateAll);

            if (isValid)
            {
                errors = Array.Empty<AnnotationError>();

                return true;
            }

            List<AnnotationError> annotationErrors = new List<AnnotationError>();

            foreach (var annotation in results)
            {
                if (annotation.MemberNames.Any())
                {
                    foreach (var memberName in annotation.MemberNames)
                    {
                        AnnotationError error = new AnnotationError(memberName, annotation.ErrorMessage);

                        annotationErrors.Add(error);
                    }
                }
                else
                {
                    AnnotationError error = new AnnotationError("Model", annotation.ErrorMessage);

                    annotationErrors.Add(error);
                }
            }

            errors = annotationErrors;

            return false;
        }
    }
}