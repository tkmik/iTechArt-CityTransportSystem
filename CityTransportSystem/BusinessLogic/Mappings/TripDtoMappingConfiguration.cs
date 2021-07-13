using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;
using System.Linq;

namespace BusinessLogic.Mappings
{
    public class TripDtoMappingConfiguration : Profile
    {
        public TripDtoMappingConfiguration()
        {
            CreateMap<TripDto, Trip>();
            CreateMap<Trip, TripDto>()
                .ForMember(t => t.StopRouteTripsId, d => d.MapFrom(s => s.StopRouteTrips.Select(c => c.Id)))
                .ForMember(t => t.TripTransportsId, d => d.MapFrom(s => s.TripTransports.Select(c => c.Id)));
        }
    }
}
