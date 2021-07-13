using AutoMapper;
using BusinessLogic.DTO;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class TripValidationViewMappingConfiguration : Profile
    {
        public TripValidationViewMappingConfiguration()
        {
            CreateMap<TripValidationViewModel, TripValidationDto>().ReverseMap();
        }
    }
}
