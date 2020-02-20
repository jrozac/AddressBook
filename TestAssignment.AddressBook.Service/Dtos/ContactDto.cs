using System.ComponentModel.DataAnnotations;

namespace TestAssignment.AddressBook.Dtos
{
    public class ContactDto : ContactDataDto
    {

        /// <summary>
        /// Id is GUID based
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Id { get; set; }

    }
}
