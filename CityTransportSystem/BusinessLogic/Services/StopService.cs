using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class StopService : IStopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StopService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<StopDto> GetStopAsync(int id)
        {
            var stop = _mapper.Map<StopDto>(await _unitOfWork.StopRepository.GetAsync(id));
            return stop;
        }

        public async Task<IEnumerable<StopDto>> GetAllStopsAsync()
        {
            var stops = _mapper.Map<IEnumerable<StopDto>>(await _unitOfWork.StopRepository.GetAllAsync());
            return stops;
        }

        public async Task AddStopAsync(StopDto stopDto)
        {
            var stop = _mapper.Map<Stop>(stopDto);
            await _unitOfWork.StopRepository.AddAsync(stop);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateStopAsync(StopDto stopDto)
        {
            var stop = _mapper.Map<Stop>(stopDto);
            await _unitOfWork.StopRepository.UpdateAsync(stop);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteStopAsync(int id)
        {
            await _unitOfWork.StopRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
