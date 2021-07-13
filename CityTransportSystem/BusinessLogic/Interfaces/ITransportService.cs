using BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITransportService
    {
        Task<TransportDto> GetTransportAsync(int id);
        Task<IEnumerable<TransportDto>> GetAllTransportsAsync();
        Task AddTransportAsync(TransportDto transportDto);
        Task UpdateTransportAsync(TransportDto transportDto);
        Task DeleteTransportAsync(int id);
    }
}
