using AutoMapper;
using BusinessLogic.DTO;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class TransportTypeViewMappingConfiguration : Profile
    {
        public TransportTypeViewMappingConfiguration()
        {
            CreateMap<TransportTypeViewModel, TransportTypeDto>().ReverseMap();
        }
    }
}
