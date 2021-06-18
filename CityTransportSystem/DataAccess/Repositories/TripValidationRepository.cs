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

        public IEnumerable<TripValidation> GetList()
        {
            return _dbContext.TripValidation;
        }
        public void Create(TripValidation item)
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
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TripVAlidationRepository()
        {
            Dispose(false);
        }
    }
}
