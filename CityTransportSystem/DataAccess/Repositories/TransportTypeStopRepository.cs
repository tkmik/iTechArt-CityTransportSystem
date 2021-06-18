using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class TransportTypeStopRepository : IRepository<TransportTypeStop>
    {
        private readonly AppDbContext _dbContext;

        public TransportTypeStopRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TransportTypeStop Get(int id)
        {
            return _dbContext.TransportTypeStop.Find(id);
        }

        public IEnumerable<TransportTypeStop> GetList()
        {
            return _dbContext.TransportTypeStop;
        }
        public void Create(TransportTypeStop item)
        {
            _dbContext.TransportTypeStop.Add(item);
        }

        public void Update(TransportTypeStop item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TransportTypeStop transportTypeStop = _dbContext.TransportTypeStop.Find(id);
            if (transportTypeStop != null)
            {
                _dbContext.Remove(transportTypeStop);
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

        ~TransportTypeStopRepository()
        {
            Dispose(false);
        }
    }
}
