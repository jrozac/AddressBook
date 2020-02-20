using System.ComponentModel.DataAnnotations;

namespace TestAssignment.AddressBook.Models
{
    public class ContactFilter
    {
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Phone]
        [StringLength(20, MinimumLength = 2)]
        public string PhoneNumber { get; set; }

        [StringLength(250, MinimumLength = 4)]
        public string Address { get; set; }
    }
}
