using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class TransportTypeRepository : GenericRepository<TransportType>, ITransportTypeRepository
    {
        public TransportTypeRepository(AppDbContext context) : base(context)
        {   }
    }
}
