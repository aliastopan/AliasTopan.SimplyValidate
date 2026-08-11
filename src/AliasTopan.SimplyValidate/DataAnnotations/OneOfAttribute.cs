using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class OneOfAttribute : ValidationAttribute
    {
        private readonly string[] _values;

        public OneOfAttribute(params string[] values)
        {
            _values = values ?? Array.Empty<string>();
        }

        public override bool IsValid(object value)
        {
            if (value == null || value.GetType() != typeof(string))
            {
                return true;
            }

            return _values.Contains((string)value);
        }

        public override string FormatErrorMessage(string name)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                return ErrorMessage;
            }

            return $"The {name} field must be one of: {string.Join(", ", _values)}.";
        }
    }
}