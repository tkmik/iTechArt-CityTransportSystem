using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;

namespace BusinessLogic.Mappings
{
    public class TicketDtoMappingConfiguration : Profile
    {
        public TicketDtoMappingConfiguration()
        {
            CreateMap<TicketDto, Ticket>().ReverseMap();
        }
    }
}
