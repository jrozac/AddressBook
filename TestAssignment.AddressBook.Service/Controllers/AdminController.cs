using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAssignment.AddressBook.Repositories;
using System.Linq;

namespace TestAssignment.AddressBook.Controllers
{

    [Controller]
    [Route("admin")]
    public class AdminController : ControllerBase
    {

        private readonly ISampleContactsRepository _sampleContactsRepository;

        private readonly IContactsRepository _contactsRepository;

        public AdminController(ISampleContactsRepository sampleContactsRepository, IContactsRepository contactsRepository)
        {
            _sampleContactsRepository = sampleContactsRepository;
            _contactsRepository = contactsRepository;
        }

        /// <summary>
        /// Deletes all existing contacts and imports sample contacts.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("contacts/reset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public ActionResult ResetContacts()
        {

            // get sample contacts
            var contacts = _sampleContactsRepository.GetSampleContacts().ToList();
            if(!contacts.Any())
            {
                return NotFound();
            }

            // delete exsisting contacts
            _contactsRepository.DeleteAll();

            // insert new contacts
            contacts.ForEach(c => _contactsRepository.Create(c));

            // return ok
            return Ok();
        }

    }
}
