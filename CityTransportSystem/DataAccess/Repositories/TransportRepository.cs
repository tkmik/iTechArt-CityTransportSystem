using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class TransportRepository : IRepository<Transport>
    {
        private readonly AppDbContext _dbContext;

        public TransportRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public Transport Get(int id)
        {
            return _dbContext.Transport.Find(id);
        }

        public IEnumerable<Transport> GetList()
        {
            return _dbContext.Transport;
        }

        public void Create(Transport item)
        {
            _dbContext.Transport.Add(item);
        }

        public void Update(Transport item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Transport transport = _dbContext.Transport.Find(id);
            if (transport != null)
            {
                _dbContext.Remove(transport);
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

        ~TransportRepository()
        {
            Dispose(false);
        }
    }
}
