using DataAccess.Interfaces;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRouteRepository RouteRepository { get; set; }
        IStopRepository StopRepository { get; set; }
        ITicketRepository TicketRepository { get; set; }
        ITransportRepository TransportRepository { get; set; }
        ITransportTypeRepository TransportTypeRepository { get; set; }
        ITripRepository TripRepository { get; set; }
        ITripValidationRepository TripValidationRepository { get; set; }
        Task SaveAsync();
    }
}
