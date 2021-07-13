using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext context) : base(context)
        { }
    }
}
