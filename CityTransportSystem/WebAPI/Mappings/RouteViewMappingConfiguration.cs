using AutoMapper;
using BusinessLogic.DTO;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class RouteViewMappingConfiguration : Profile
    {

        public RouteViewMappingConfiguration()
        {
            CreateMap<RouteViewModel, RouteDto>().ReverseMap();
        }
    }
}
