using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;
using System.Linq;

namespace BusinessLogic.Mappings
{
    public class TransportTypeDtoMappingConfiguration : Profile
    {
        public TransportTypeDtoMappingConfiguration()
        {
            CreateMap<TransportTypeDto, TransportType>();
            CreateMap<TransportType, TransportTypeDto>()
                .ForMember(t => t.TransportsId, d => d.MapFrom(s => s.Transports.Select(c => c.Id)))
                .ForMember(t => t.TransportTypeStopsId, d => d.MapFrom(s => s.TransportTypeStops.Select(c => c.Id)));
        }
    }
}
