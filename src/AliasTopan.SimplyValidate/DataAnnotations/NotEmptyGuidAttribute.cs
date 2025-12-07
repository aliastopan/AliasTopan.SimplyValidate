using System;
using System.ComponentModel.DataAnnotations;

namespace AliasTopan.SimplyValidate.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NotEmptyGuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is Guid guid)
            {
                return guid != Guid.Empty;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                return ErrorMessage;
            }

            return $"The {name} field is required and cannot be the empty Guid.";
        }
    }
}
