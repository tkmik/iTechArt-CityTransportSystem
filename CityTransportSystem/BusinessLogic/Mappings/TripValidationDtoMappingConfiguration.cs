using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;
using System.Linq;

namespace BusinessLogic.Mappings
{
    public class TripValidationDtoMappingConfiguration : Profile
    {
        public TripValidationDtoMappingConfiguration()
        {
            CreateMap<TripValidationDto, TripValidation>();
            CreateMap<TripValidation, TripValidationDto>()
                .ForMember(t => t.TicketsId, d => d.MapFrom(s => s.Tickets.Select(c => c.Id)));
        }
    }
}
