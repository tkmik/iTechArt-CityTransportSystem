using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TripValidationService : ITripValidation
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TripValidationService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<TripValidationDto> GetTripValidationAsync(int id)
        {
            var tripValidation = _mapper.Map<TripValidationDto>(await _unitOfWork.TripValidationRepository.GetAsync(id));
            return tripValidation;
        }

        public async Task<IEnumerable<TripValidationDto>> GetAllTripValidationsAsync()
        {
            var tripValidations = _mapper.Map<IEnumerable<TripValidationDto>>(await _unitOfWork.TripValidationRepository.GetAllAsync());
            return tripValidations;
        }

        public async Task AddTripValidationAsync(TripValidationDto tripValidationDto)
        {
            var tripValidation = _mapper.Map<TripValidation>(tripValidationDto);
            await _unitOfWork.TripValidationRepository.AddAsync(tripValidation);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTripValidationAsync(TripValidationDto tripValidationDto)
        {
            var tripValidation = _mapper.Map<TripValidation>(tripValidationDto);
            await _unitOfWork.TripValidationRepository.UpdateAsync(tripValidation);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTripValidationAsync(int id)
        {
            await _unitOfWork.TripValidationRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
