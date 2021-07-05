using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class StopRepository : GenericRepository<Stop>, IStopRepository
    {
        public StopRepository(AppDbContext context) : base(context)
        {   }
    }
}
