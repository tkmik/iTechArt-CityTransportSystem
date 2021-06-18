using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class RouteRepository : IRepository<Route>
    {
        private readonly AppDbContext _dbContext;

        public RouteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Route Get(int id)
        {
            return _dbContext.Route.Find(id);
        }

        public IEnumerable<Route> GetList()
        {
            return _dbContext.Route;
        }

        public void Create(Route item)
        {
            _dbContext.Route.Add(item);
        }

        public void Update(Route item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Route route = _dbContext.Route.Find(id);
            if (route != null)
            {
                _dbContext.Route.Remove(route);
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

        ~RouteRepository()
        {
            Dispose(false);
        }
    }
}
