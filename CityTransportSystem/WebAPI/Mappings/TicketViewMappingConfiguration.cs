using AutoMapper;
using BusinessLogic.DTO;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class TicketViewMappingConfiguration : Profile
    {
        public TicketViewMappingConfiguration()
        {
            CreateMap<TicketViewModel, TicketDto>().ReverseMap();
        }
    }
}
