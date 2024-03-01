using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Vidly.Dtos;
using Vidly.ViewModels;

namespace Vidly.Models
{
    public class Min18YearsIfIsAMember: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            dynamic customer;
            if (validationContext.ObjectInstance is CustomerFormViewModel)            
                customer = validationContext.ObjectInstance as CustomerFormViewModel;
            else
                customer = validationContext.ObjectInstance as CustomerDto;


            

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 4)
            {
                return ValidationResult.Success;
            }

            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age= DateTime.Now.Year - customer.Birthdate.Year;

            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Age must be over 18");
            

            
        }
    }
}
