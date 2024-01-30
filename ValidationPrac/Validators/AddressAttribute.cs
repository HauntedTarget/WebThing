using System.ComponentModel.DataAnnotations;
using ValidationPrac.Models;

namespace ValidationPrac.Validators
{
    public class AddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var v = (Validation)validationContext.ObjectInstance;

            if (!String.IsNullOrEmpty(v.Street) && 
                !String.IsNullOrEmpty(v.City) && 
                !String.IsNullOrEmpty(v.State) && 
                !String.IsNullOrEmpty(v.ZipCode))
            {
                return ValidationResult.Success;
            }
            else if (String.IsNullOrEmpty(v.Street) && 
                String.IsNullOrEmpty(v.City) && 
                String.IsNullOrEmpty(v.State) && 
                String.IsNullOrEmpty(v.ZipCode))
            {
                return ValidationResult.Success;
            }
            else { return new ValidationResult("Address not filled in full!", new List<string>() { "ZipCode" }); }
        }
    }
}
