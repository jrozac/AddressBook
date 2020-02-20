using System.ComponentModel.DataAnnotations;

namespace TestAssignment.AddressBook.Models
{
    public class PagingFilter
    {
        [Range(0, int.MaxValue)]
        public int Offset { get; set; }

        [Range(1, 1000)]
        [Required]
        public int PageRecords { get; set; }
    }
}
