using AutoMapper;
using BusinessLogic.DTO;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class TripViewMappingConfiguration : Profile
    {
        public TripViewMappingConfiguration()
        {
            CreateMap<TripViewModel, TripDto>().ReverseMap();
        }
    }
}
