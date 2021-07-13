using BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDto> GetTicketAsync(int id);
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
        Task AddTicketAsync(TicketDto ticketDto);
        Task UpdateTicketAsync(TicketDto ticketDto);
        Task DeleteTicketAsync(int id);
    }
}
