using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;
using System.Linq;

namespace BusinessLogic.Mappings
{
    public class RouteDtoMappingConfiguration : Profile
    {

        public RouteDtoMappingConfiguration()
        {
            CreateMap<RouteDto, Route>();
            CreateMap<Route, RouteDto>()
                .ForMember(r => r.TripsId, d => d.MapFrom(s => s.Trips.Select(c => c.Id)))
                .ForMember(r => r.StopRoutesId, d => d.MapFrom(s => s.StopRoutes.Select(c => c.Id)));
        }
    }
}
