using AutoMapper;
using TestAssignment.AddressBook.Dtos;
using TestAssignment.AddressBook.Models;

namespace TestAssignment.AddressBook.Service
{
    /// <summary>
    /// Objects mappings definition profile
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // map filters
            CreateMap<ContactFilterDto, ContactFilter>();
            CreateMap<ContactFilterDto, PagingFilter>();

            // map data
            CreateMap<PagedList<Contact>, PagedListDto<ContactDto>>();
            CreateMap<Paging, PagingDto>();
            CreateMap<ContactDataDto, Contact>();
            CreateMap<ContactDto, Contact>().ReverseMap();
        }
    }
}
