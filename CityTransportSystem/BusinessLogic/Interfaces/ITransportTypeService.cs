using BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITransportTypeService
    {
        Task<TransportTypeDto> GetTransportTypeAsync(int id);
        Task<IEnumerable<TransportTypeDto>> GetAllTransportTypesAsync();
        Task AddTransportTypeAsync(TransportTypeDto transportTypeDto);
        Task UpdateTransportTypeAsync(TransportTypeDto transportTypeDto);
        Task DeleteTransportTypeAsync(int id);
    }
}
