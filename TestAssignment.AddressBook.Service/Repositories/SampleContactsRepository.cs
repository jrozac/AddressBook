using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestAssignment.AddressBook.Models;

namespace TestAssignment.AddressBook.Repositories
{
    public class SampleContactsRepository : ISampleContactsRepository
    {

        /// <summary>
        /// Get contacts from file with same data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetSampleContacts()
        {
            return File.ReadAllLines("sampleContacts.csv").Skip(1).Select(line =>
            {
                var items = line.Split(",").Select(i => i.Replace("\"", "").Trim()).ToArray();
                return new Contact
                {
                    FirstName = items[0],
                    LastName = items[1],
                    PhoneNumber = items[8].Replace("-", ""),
                    Address = $"{items[3]}, {items[4]}, {items[5]}, {items[6]}, {items[7]}"
                };

            }).GroupBy(p => p.PhoneNumber).Select(l => l.First()).ToArray();
        }
    }
}
