using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Helpers
{
    public class MyCustomAttributeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string description = value.ToString();
                if(description.Length > 35)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Dcription should be more than 35 characters.");
        }
    }
}
