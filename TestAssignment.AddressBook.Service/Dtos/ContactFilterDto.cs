using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TestAssignment.AddressBook.Dtos
{
    public class ContactFilterDto : PagingFilterDto
    {

        [BindProperty(Name = "firstName")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [BindProperty(Name = "lastName")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Phone]
        [BindProperty(Name = "phoneNumber")]
        [StringLength(20, MinimumLength = 2)]
        public string PhoneNumber { get; set; }

        [BindProperty(Name = "address")]
        [StringLength(250, MinimumLength = 4)]
        public string Address { get; set; }
    }
}
