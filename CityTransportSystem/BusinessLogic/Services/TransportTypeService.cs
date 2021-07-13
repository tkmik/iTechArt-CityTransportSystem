using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TransportTypeService : ITransportTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TransportTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<TransportTypeDto> GetTransportTypeAsync(int id)
        {
            var transportType = _mapper.Map<TransportTypeDto>(await _unitOfWork.TransportTypeRepository.GetAsync(id));
            return transportType;
        }

        public async Task<IEnumerable<TransportTypeDto>> GetAllTransportTypesAsync()
        {
            var transportTypes = _mapper.Map<IEnumerable<TransportTypeDto>>(await _unitOfWork.TransportTypeRepository.GetAllAsync());
            return transportTypes;
        }

        public async Task AddTransportTypeAsync(TransportTypeDto transportTypeDto)
        {
            var transportType = _mapper.Map<TransportType>(transportTypeDto);
            await _unitOfWork.TransportTypeRepository.AddAsync(transportType);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTransportTypeAsync(TransportTypeDto transportTypeDto)
        {
            var transportType = _mapper.Map<TransportType>(transportTypeDto);
            await _unitOfWork.TransportTypeRepository.UpdateAsync(transportType);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTransportTypeAsync(int id)
        {
            await _unitOfWork.TransportTypeRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
