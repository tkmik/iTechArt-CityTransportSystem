using BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITripService
    {
        Task<TripDto> GetTripAsync(int id);
        Task<IEnumerable<TripDto>> GetAllTripsAsync();
        Task AddTripAsync(TripDto tripDto);
        Task UpdateTripAsync(TripDto tripDto);
        Task DeleteTripAsync(int id);
    }
}
