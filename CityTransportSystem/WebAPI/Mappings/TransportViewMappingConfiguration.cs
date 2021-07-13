using AutoMapper;
using BusinessLogic.DTO;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class TransportViewMappingConfiguration : Profile
    {
        public TransportViewMappingConfiguration()
        {
            CreateMap<TransportViewModel, TransportDto>().ReverseMap();
        }
    }
}
