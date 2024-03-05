using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribeToNewsletter { get; set; }


        [Required]
        public int MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

     
        [Min18YearsIfIsAMember]
        public DateTime? Birthdate { get; set; }
    }
}
