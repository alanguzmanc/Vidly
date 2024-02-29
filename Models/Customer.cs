using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }        
        public MembershipType? MembershipType { get; set; }


        [Required]
        [Display(Name = "Membership Type")]       
        public int MembershipTypeId { get; set; }

        


        [Display(Name = "Date of birdth")]
        //[Min18YearsIfIsAMember]
        public DateTime? Birthdate { get; set; }
    }
}
