using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class StopRepository : IRepository<Stop>
    {
        private readonly AppDbContext _dbContext;

        public StopRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Stop Get(int id)
        {
            return _dbContext.Stop.Find(id);
        }

        public IEnumerable<Stop> GetList()
        {
            return _dbContext.Stop;
        }

        public void Create(Stop item)
        {
            _dbContext.Stop.Add(item);
        }

        public void Update(Stop item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Stop stop = _dbContext.Stop.Find(id);
            if (stop != null)
            {
                _dbContext.Stop.Remove(stop);
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

        ~StopRepository()
        {
            Dispose(false);
        }
    }
}
