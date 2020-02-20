using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAssignment.AddressBook.Models
{

    [Table("CONTACT")]
    public class Contact
    {

        /// <summary>
        /// Id is GUID based
        /// </summary>
        [Key]
        [Column("ID")]
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string Id { get; set; }

        [Column("FIRST_NAME")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Column("LAST_NAME")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Column("PHONE")]
        [Required]
        [Phone]
        [StringLength(20, MinimumLength = 2)]
        public string PhoneNumber { get; set; }

        [Column("ADDRESS")]
        [Required]
        [StringLength(250, MinimumLength = 4)]
        public string Address { get; set; }
    }
}
