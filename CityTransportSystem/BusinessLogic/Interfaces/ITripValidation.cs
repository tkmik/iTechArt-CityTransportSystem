using BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITripValidation
    {
        Task<TripValidationDto> GetTripValidationAsync(int id);
        Task<IEnumerable<TripValidationDto>> GetAllTripValidationsAsync();
        Task AddTripValidationAsync(TripValidationDto tripValidationDto);
        Task UpdateTripValidationAsync(TripValidationDto tripValidationDto);
        Task DeleteTripValidationAsync(int id);
    }
}
