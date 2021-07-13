using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;
using System.Linq;

namespace BusinessLogic.Mappings
{
    public class StopDtoMappingConfiguration : Profile
    {
        public StopDtoMappingConfiguration()
        {
            CreateMap<StopDto, Stop>();
            CreateMap<Stop, StopDto>()
                .ForMember(s => s.StopRoutesId, d => d.MapFrom(r => r.StopRoutes.Select(c => c.Id)))
                .ForMember(s => s.TransportTypeStopsId, d => d.MapFrom(r => r.TransportTypeStops.Select(C => C.Id)));
        }
    }
}
