using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebSample.Resources;

namespace WebSample.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class EmailValidationAttribute : ValidationAttribute
    {
        private const string RegexString = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var check = Regex.IsMatch(value.ToString(), RegexString, RegexOptions.IgnoreCase);
                if (check)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessages.InvalidEmailAddress);
        }
    }
}