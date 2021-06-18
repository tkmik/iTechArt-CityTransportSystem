using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class TripTransportRepository : IRepository<TripTransport>
    {
        private readonly AppDbContext _dbContext;

        public TripTransportRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TripTransport Get(int id)
        {
            return _dbContext.TripTransport.Find(id);
        }

        public IEnumerable<TripTransport> GetList()
        {
            return _dbContext.TripTransport;
        }
        public void Create(TripTransport item)
        {
            _dbContext.TripTransport.Add(item);
        }
        public void Update(TripTransport item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            TripTransport tripTransport = _dbContext.TripTransport.Find(id);
            if (tripTransport != null)
            {
                _dbContext.Remove(tripTransport);
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

        ~TripTransportRepository()
        {
            Dispose(false);
        }
    }
}
