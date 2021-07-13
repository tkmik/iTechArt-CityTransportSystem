using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;

namespace BusinessLogic.Mappings
{
    public class TransportDtoMappingConfiguration : Profile
    {
        public TransportDtoMappingConfiguration()
        {
            CreateMap<TransportDto, Transport>().ReverseMap();
        }
    }
}
