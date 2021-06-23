using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class TripVAlidationRepository : IRepository<TripValidation>
    {
        private readonly AppDbContext _dbContext;

        public TripVAlidationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TripValidation Get(int id)
        {
            return _dbContext.TripValidation.Find(id);
        }

        public IEnumerable<TripValidation> GetAll()
        {
            return _dbContext.TripValidation;
        }
        public void Add(TripValidation item)
        {
            _dbContext.TripValidation.Add(item);
        }

        public void Update(TripValidation item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            TripValidation tripValidation = _dbContext.TripValidation.Find(id);
            if (tripValidation != null)
            {
                _dbContext.Remove(tripValidation);
            }
        }
    }
}
