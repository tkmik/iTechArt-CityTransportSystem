using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(AppDbContext context) : base(context)
        { }
    }
}
