using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class TripValidationRepository : GenericRepository<TripValidation>, ITripValidationRepository
    {
        public TripValidationRepository(AppDbContext context) : base(context)
        { }
    }
}
