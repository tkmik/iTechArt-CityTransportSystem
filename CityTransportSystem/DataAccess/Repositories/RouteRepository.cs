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

        public IEnumerable<Route> GetAll()
        {
            return _dbContext.Route;
        }

        public void Add(Route item)
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
    }
}
