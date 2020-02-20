using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestAssignment.AddressBook.Models;

namespace TestAssignment.AddressBook.Repositories
{
    public class ContactsRepository : IContactsRepository
    {

        private readonly PhoneDbContext _dbContext;

        public ContactsRepository(PhoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Contact Delete(string id)
        {
            // get record
            var obj = _dbContext.Contacts.Find(id);
            if(obj == null)
            {
                return null;
            }

            // delete record
            _dbContext.Contacts.Remove(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public Contact Get(string id)
        {
            return _dbContext.Contacts.Find(id);
        }

        public Contact GetByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        }

        public Contact Create(Contact obj)
        {
            obj.Id = string.IsNullOrWhiteSpace(obj.Id) ? Guid.NewGuid().ToString("N") : obj.Id;
            var ent = _dbContext.Contacts.Add(obj);
            _dbContext.SaveChanges();
            return ent.Entity;
        }

        public Contact Update(Contact obj)
        {
            /// check for existing item
            var objEx = Get(obj.Id);
            if(objEx == null)
            {
                return null;
            }

            // perform update
            _dbContext.Entry(obj).State = EntityState.Modified;
            var ent = _dbContext.Contacts.Update(obj);
            _dbContext.SaveChanges();
            return ent.Entity;
        }

        public PagedList<Contact> Search(ContactFilter filter, PagingFilter paging)
        {
            // set query criteria
            var query = _dbContext.Contacts.AsQueryable();
            if(!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                query = query.Where(p => p.FirstName.Contains(filter.FirstName));
            }
            if (!string.IsNullOrWhiteSpace(filter.LastName))
            {
                query = query.Where(p => p.LastName.Contains(filter.LastName));
            }
            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
            {
                query = query.Where(p => p.PhoneNumber.Contains(filter.PhoneNumber));
            }
            if (!string.IsNullOrWhiteSpace(filter.Address))
            {
                query = query.Where(p => p.Address.Contains(filter.Address));
            }

            // count all records
            var allRecordsCount = query.Count();

            // offset apply
            query = query.Skip(paging.Offset);

            // get records
            var records = query.Take(paging.PageRecords).ToList();

            // return data
            var pagedList = new PagedList<Contact>
            {
                List = records,
                Paging = new Paging
                {
                    AllRecords = allRecordsCount,
                    Offset = paging.Offset,
                    PageRecords = paging.PageRecords
                }
            };
            return pagedList;

        }

        public void DeleteAll()
        {
            _dbContext.Contacts.RemoveRange(_dbContext.Contacts);
            _dbContext.SaveChanges();
        }
    }
}
