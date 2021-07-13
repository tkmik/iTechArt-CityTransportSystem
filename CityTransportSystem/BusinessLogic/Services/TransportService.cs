using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TransportService : ITransportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TransportService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<TransportDto> GetTransportAsync(int id)
        {
            var transport = _mapper.Map<TransportDto>(await _unitOfWork.TransportRepository.GetAsync(id));
            return transport;
        }

        public async Task<IEnumerable<TransportDto>> GetAllTransportsAsync()
        {
            var transports = _mapper.Map<IEnumerable<TransportDto>>(await _unitOfWork.TransportRepository.GetAllAsync());
            return transports;
        }

        public async Task AddTransportAsync(TransportDto transportDto)
        {
            var transport = _mapper.Map<Transport>(transportDto);
            await _unitOfWork.TransportRepository.AddAsync(transport);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTransportAsync(TransportDto transportDto)
        {
            var transport = _mapper.Map<Transport>(transportDto);
            await _unitOfWork.TransportRepository.UpdateAsync(transport);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTransportAsync(int id)
        {
            await _unitOfWork.TransportRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
