using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TripService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<TripDto> GetTripAsync(int id)
        {
            var trip = _mapper.Map<TripDto>(await _unitOfWork.TripRepository.GetAsync(id));
            return trip;
        }

        public async Task<IEnumerable<TripDto>> GetAllTripsAsync()
        {
            var trips = _mapper.Map<IEnumerable<TripDto>>(await _unitOfWork.TripRepository.GetAllAsync());
            return trips;
        }

        public async Task AddTripAsync(TripDto tripDto)
        {
            var trip = _mapper.Map<Trip>(tripDto);
            await _unitOfWork.TripRepository.AddAsync(trip);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTripAsync(TripDto tripDto)
        {
            var trip = _mapper.Map<Trip>(tripDto);
            await _unitOfWork.TripRepository.UpdateAsync(trip);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTripAsync(int id)
        {
            await _unitOfWork.TripRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
