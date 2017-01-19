using System;
using System.ComponentModel.DataAnnotations;
using WebSample.Resources;

namespace WebSample.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class AgeValidationAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;
        public AgeValidationAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime inputDate;
                if (DateTime.TryParse(value.ToString(), out inputDate))
                {
                    var check = (inputDate.AddYears(_minimumAge) < DateTime.Now);
                    if (check)
                        return ValidationResult.Success;
                }
            }
            var errorMessage = String.Format(ErrorMessages.AgeNotMatched, _minimumAge);
            return new ValidationResult(errorMessage);
        }
    }
}