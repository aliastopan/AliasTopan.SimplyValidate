using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate
{
    internal static class AnnotationValidator
    {
        public static List<ValidationError> ValidateObject(object instance)
        {
            List<ValidationError> errors = new List<ValidationError>();

            ValidateObjectRecursive(instance, errors, parentProperty: string.Empty);

            return errors;
        }

        private static void ValidateObjectRecursive(object instance, List<ValidationError> errors, string parentProperty)
        {
            if (instance == null)
            {
                return;
            }

            TopLevelPropertiesValidation(instance, errors, parentProperty);
            NestedPropertiesValidation(instance, errors, parentProperty);
        }

        /// <summary>
        /// Validates top-level properties of the given instance.
        /// </summary>
        private static void TopLevelPropertiesValidation(object instance, List<ValidationError> errors, string parentProperty)
        {
            ValidationContext context = new ValidationContext(instance);
            List<ValidationResult> results = new List<ValidationResult>();

            Validator.TryValidateObject(instance, context, results, true);

            foreach (ValidationResult result in results)
            {
                if (result is CompositeValidationResult)
                    continue;

                IEnumerable<string> memberNames = result.MemberNames.Any()
                    ? result.MemberNames
                    : new[] { string.Empty };

                foreach (string memberName in memberNames)
                {
                    string member = string.IsNullOrEmpty(parentProperty)
                        ? memberName
                        : $"{parentProperty}.{memberName}";

                    errors.Add(new ValidationError(member, result.ErrorMessage));
                }
            }
        }

        /// <summary>
        /// Validates nested properties.
        /// </summary>
        private static void NestedPropertiesValidation(object instance, List<ValidationError> errors, string parentProperty)
        {
            PropertyInfo[] properties = instance.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (!property.IsDefined(typeof(NestedValidateAttribute), true))
                    continue;

                object propertyValue = property.GetValue(instance);
                string newPrefix = string.IsNullOrEmpty(parentProperty)
                    ? property.Name
                    : $"{parentProperty}.{property.Name}";

                HandleNestedPropertyValue(propertyValue, errors, newPrefix);
            }
        }

        /// <summary>
        /// Determines if a nested property is a collection or a single object and validates accordingly.
        /// </summary>
        private static void HandleNestedPropertyValue(object propertyValue, List<ValidationError> errors, string propertyPrefix)
        {
            if (propertyValue == null)
                return;

            bool isEnumerable = propertyValue is IEnumerable;
            bool notString = !(propertyValue is string);

            // Case 1: The property is a collection of objects.
            if (isEnumerable && notString)
            {
                IEnumerable enumerable = propertyValue as IEnumerable;
                int index = 0;

                foreach (object item in enumerable)
                {
                    ValidateObjectRecursive(item, errors, $"{propertyPrefix}[{index}]");
                    index++;
                }

                return;
            }

            // Case 2: The property is a single object.
            ValidateObjectRecursive(propertyValue, errors, propertyPrefix);
        }
    }
}