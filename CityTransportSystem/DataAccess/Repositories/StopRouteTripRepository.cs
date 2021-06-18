using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class StopRouteTripRepository : IRepository<StopRouteTrip>
    {
        private readonly AppDbContext _dbContext;

        public StopRouteTripRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StopRouteTrip Get(int id)
        {
            return _dbContext.StopRouteTrip.Find(id);
        }

        public IEnumerable<StopRouteTrip> GetList()
        {
            return _dbContext.StopRouteTrip;
        }

        public void Create(StopRouteTrip item)
        {
            _dbContext.StopRouteTrip.Add(item);
        }

        public void Update(StopRouteTrip item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            StopRouteTrip stopRouteTrip = _dbContext.StopRouteTrip.Find(id);
            if (stopRouteTrip != null)
            {
                _dbContext.Remove(stopRouteTrip);
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

        ~StopRouteTripRepository()
        {
            Dispose(false);
        }
    }
}
