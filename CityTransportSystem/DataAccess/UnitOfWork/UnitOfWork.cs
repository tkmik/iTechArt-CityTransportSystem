using DataAccess.EF;
using DataAccess.Interfaces;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(
            AppDbContext context,
            IRouteRepository routeRepository,
            IStopRepository stopRepository,
            ITicketRepository ticketRepository,
            ITransportRepository transportRepository,
            ITransportTypeRepository transportTypeRepository,
            ITripRepository tripRepository,
            ITripValidationRepository tripValidationRepository
            )
        {
            _context = context;
            RouteRepository = routeRepository;
            StopRepository = stopRepository;
            TicketRepository = ticketRepository;
            TransportRepository = transportRepository;
            TransportTypeRepository = transportTypeRepository;
            TripRepository = tripRepository;
            TripValidationRepository = tripValidationRepository;
        }

        public IRouteRepository RouteRepository { get; set; }
        public IStopRepository StopRepository { get; set; }
        public ITicketRepository TicketRepository { get; set; }
        public ITransportRepository TransportRepository { get; set; }
        public ITransportTypeRepository TransportTypeRepository { get; set; }
        public ITripRepository TripRepository { get; set; }
        public ITripValidationRepository TripValidationRepository { get; set; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
