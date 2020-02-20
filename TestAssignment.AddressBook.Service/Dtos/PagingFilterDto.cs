using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TestAssignment.AddressBook.Dtos
{

    /// <summary>
    /// Paging filter
    /// </summary>
    public abstract class PagingFilterDto
    {
        [BindProperty(Name = "offset")]
        [Range(0, int.MaxValue)]
        public int Offset { get; set; }

        [BindProperty(Name = "pageRecords")]
        [Range(1, 1000)]
        [Required]
        public int PageRecords { get; set; }
    }
}
