using System;
using System.ComponentModel.DataAnnotations;
using WebSample.Resources;

namespace WebSample.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredExAttribute : ValidationAttribute
    {
        public bool AllowEmptyStrings { set; get; }        

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessage = String.Format(ErrorMessages.RequiredFieldMissed, validationContext.DisplayName);
            if (value == null)
                return new ValidationResult(errorMessage);

            string str = value as string;
            if (str != null && !AllowEmptyStrings)
            {
                var check = ((uint) str.Trim().Length > 0U);
                if(!check)
                    return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}