using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class TripRepository : IRepository<Trip>
    {
        private readonly AppDbContext _dbContext;

        public TripRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Trip Get(int id)
        {
            return _dbContext.Trip.Find(id);
        }

        public IEnumerable<Trip> GetList()
        {
            return _dbContext.Trip;
        }
        public void Create(Trip item)
        {
            _dbContext.Trip.Add(item);
        }
        public void Update(Trip item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Trip trip = _dbContext.Trip.Find(id);
            if (trip != null)
            {
                _dbContext.Remove(trip);
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

        ~TripRepository()
        {
            Dispose(false);
        }
    }
}
