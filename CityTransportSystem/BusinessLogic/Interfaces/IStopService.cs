using BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IStopService
    {
        Task<StopDto> GetStopAsync(int id);
        Task<IEnumerable<StopDto>> GetAllStopsAsync();
        Task AddStopAsync(StopDto stopDto);
        Task UpdateStopAsync(StopDto stopDto);
        Task DeleteStopAsync(int id);
    }
}
