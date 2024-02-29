using System.ComponentModel.DataAnnotations;
using Vidly.ViewModels;

namespace Vidly.Models
{
    public class Min18YearsIfIsAMember: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as CustomerFormViewModel;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 4)
            {
                return ValidationResult.Success;
            }

            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age= DateTime.Now.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Age must be over 18");
            

            
        }
    }
}
