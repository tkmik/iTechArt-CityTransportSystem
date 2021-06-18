using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class TransportTypeRepository : IRepository<TransportType>
    {
        private readonly AppDbContext _dbContext;

        public TransportTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TransportType Get(int id)
        {
            return _dbContext.TransportType.Find(id);
        }

        public IEnumerable<TransportType> GetList()
        {
            return _dbContext.TransportType;
        }

        public void Create(TransportType item)
        {
            _dbContext.TransportType.Add(item);
        }

        public void Update(TransportType item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TransportType transportType = _dbContext.TransportType.Find(id);
            if (transportType != null)
            {
                _dbContext.Remove(transportType);
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

        ~TransportTypeRepository()
        {
            Dispose(false);
        }
    }
}
