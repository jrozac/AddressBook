using TestAssignment.AddressBook.Models;

namespace TestAssignment.AddressBook.Repositories
{

    /// <summary>
    /// Interface for contacts repositories.
    /// </summary>
    public interface IContactsRepository
    {
        Contact Get(string id);

        Contact Create(Contact obj);

        Contact Update(Contact obj);

        Contact GetByPhoneNumber(string phoneNumber);

        Contact Delete(string id);

        PagedList<Contact> Search(ContactFilter filter, PagingFilter paging);

        /// <summary>
        /// Delete all records
        /// </summary>
        void DeleteAll();

    }
}
