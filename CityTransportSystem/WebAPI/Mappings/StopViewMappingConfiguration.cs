using AutoMapper;
using BusinessLogic.DTO;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class StopViewMappingConfiguration : Profile
    {
        public StopViewMappingConfiguration()
        {
            CreateMap<StopViewModel, StopDto>().ReverseMap();
        }
    }
}
