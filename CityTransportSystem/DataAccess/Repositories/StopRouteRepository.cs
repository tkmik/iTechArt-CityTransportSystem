using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class StopRouteRepository : IRepository<StopRoute>
    {
        private readonly AppDbContext _dbContext;

        public StopRouteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StopRoute Get(int id)
        {
            return _dbContext.StopRoute.Find(id);
        }

        public IEnumerable<StopRoute> GetList()
        {
            return _dbContext.StopRoute;
        }

        public void Create(StopRoute item)
        {
            _dbContext.StopRoute.Add(item);
        }

        public void Update(StopRoute item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            StopRoute stopRoute = _dbContext.StopRoute.Find(id);
            if (stopRoute != null)
            {
                _dbContext.StopRoute.Remove(stopRoute);
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

        ~StopRouteRepository()
        {
            Dispose(false);
        }
    }
}
