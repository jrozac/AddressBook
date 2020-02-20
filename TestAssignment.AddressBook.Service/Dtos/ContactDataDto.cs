using System.ComponentModel.DataAnnotations;
using TestAssignment.AddressBook.DataValidation;

namespace TestAssignment.AddressBook.Dtos
{
    public class ContactDataDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [PhoneUnique]
        [Phone]
        [StringLength(20, MinimumLength = 2)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 4)]
        public string Address { get; set; }
    }
}
