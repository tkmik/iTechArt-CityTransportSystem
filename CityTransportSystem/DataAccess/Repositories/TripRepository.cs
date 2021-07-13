using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(AppDbContext context) : base(context)
        { }
    }
}
