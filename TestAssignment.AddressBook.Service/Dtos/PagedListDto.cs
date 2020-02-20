using System.Collections.Generic;

namespace TestAssignment.AddressBook.Dtos
{
    public class PagedListDto<T> where T : class
    {
        public IEnumerable<T> List { get; set; }

        public PagingDto Paging { get; set; }
    }
}
