using BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRouteService
    {
        Task<RouteDto> GetRouteAsync(int id);
        Task<IEnumerable<RouteDto>> GetAllRoutesAsync();
        Task AddRouteAsync(RouteDto routeDto);
        Task UpdateRouteAsync(RouteDto routeDto);
        Task DeleteRouteAsync(int id);
    }
}
