using System.Collections.Generic;
using TestAssignment.AddressBook.Models;

namespace TestAssignment.AddressBook.Repositories
{

    /// <summary>
    /// Sample contacts service
    /// </summary>
    public interface ISampleContactsRepository
    {
        IEnumerable<Contact> GetSampleContacts();
    }
}
