using System;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ParsableEnumAttribute : ValidationAttribute
    {
        public Type EnumType { get; }
        public bool IgnoreCase { get; set; } = true;

        public ParsableEnumAttribute(Type enumType)
        {
            if (enumType == null || !enumType.IsEnum)
            {
                throw new ArgumentException("The type provided must be an Enum.", nameof(enumType));
            }

            EnumType = enumType;
        }

        public override bool IsValid(object value)
        {
            if (value == null || !(value is string stringValue))
            {
                return true;
            }

            if (string.IsNullOrEmpty(stringValue))
            {
                return true;
            }

            try
            {
                Enum.Parse(EnumType, stringValue, IgnoreCase);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                return ErrorMessage;
            }

            string validOptions = string.Join(", ", Enum.GetNames(EnumType));
            return $"The {name} field must be one of the following values: {validOptions}.";
        }
    }
}
