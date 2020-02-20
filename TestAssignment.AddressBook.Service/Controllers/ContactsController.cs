using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAssignment.AddressBook.Dtos;
using TestAssignment.AddressBook.Models;
using TestAssignment.AddressBook.Repositories;

namespace TestAssignment.AddressBook.Service.Controllers
{
    [Controller]
    [Route("contacts")]
    public class ContactsController : ControllerBase
    {

        private readonly IContactsRepository _repository;

        private readonly IMapper _mapper;

        public ContactsController(IContactsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Search contacts
        /// </summary>
        /// <param name="filterDto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(PagedListDto<ContactDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelErrorDto), StatusCodes.Status400BadRequest)]
        public ActionResult<PagedListDto<ContactDto>> Search([FromQuery] ContactFilterDto filterDto)
        {

            // map filters
            var filter = _mapper.Map<ContactFilter>(filterDto);
            var paging = _mapper.Map<PagingFilter>(filterDto);

            // query repository
            var pagedList = _repository.Search(filter, paging);

            // map to dto and return
            var pagedListDto = _mapper.Map<PagedListDto<ContactDto>>(pagedList);
            return pagedListDto;
            
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Ok</response>
        /// <response code="410">Gone</response>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status410Gone)]
        [ProducesErrorResponseType(typeof(void))]
        public ActionResult Delete(string id)
        {
            var obj = _repository.Delete(id);
            return new StatusCodeResult(obj != null ? StatusCodes.Status204NoContent : StatusCodes.Status410Gone);
        }

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status410Gone)]
        [ProducesResponseType(typeof(ModelErrorDto), StatusCodes.Status400BadRequest)]
        public ActionResult<ContactDto> Update([FromBody] ContactDto dto)
        {
            // update record
            var obj = _mapper.Map<Contact>(dto);
            obj = _repository.Update(obj);
            if(obj == null)
            {
                return new StatusCodeResult(StatusCodes.Status410Gone);
            }

            // map and return updated recrod
            dto = _mapper.Map<ContactDto>(obj);
            return Ok(dto);
        }

        /// <summary>
        /// Create new contact
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ModelErrorDto), StatusCodes.Status400BadRequest)]
        public ActionResult<ContactDto> Create([FromBody] ContactDataDto dto)
        {
            var obj = _mapper.Map<Contact>(dto);
            obj = _repository.Create(obj);
            dto = _mapper.Map<ContactDto>(obj);
            return Created("", dto);
        }

        /// <summary>
        /// Get contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public ActionResult<ContactDto> Get(string id)
        {
            // get object
            var obj = _repository.Get(id);
            if(obj == null)
            {
                return NotFound();
            }

            // map and return
            var dto = _mapper.Map<ContactDto>(obj);
            return Ok(dto);
        }
    }
}
