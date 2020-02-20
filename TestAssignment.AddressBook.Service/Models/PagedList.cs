using System.Collections.Generic;

namespace TestAssignment.AddressBook.Models
{
    public class PagedList<T> where T : class
    {
        public IEnumerable<T> List { get; set; }

        public Paging Paging { get; set; }
    }
}