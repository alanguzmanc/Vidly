using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {      


        public CustomerFormViewModel() 
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer, IEnumerable<MembershipType> membershipTypes) { 
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribeToNewsletter = customer.IsSubscribeToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
            MembershipTypes = membershipTypes;
        }

        public IEnumerable<MembershipType>? MembershipTypes { get; set;}
       
        public string Title {
            get 
            {
                return (Id != 0) ? "Edit" : "New";
            }
        }


        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }



        [Required]
        [Display(Name = "Membership Type")]
        public int? MembershipTypeId { get; set; }


        [Display(Name = "Date of birdth")]
        [Min18YearsIfIsAMember]
        public DateTime? Birthdate { get; set; }
    }
}
