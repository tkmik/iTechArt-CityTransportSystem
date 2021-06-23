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

        public IEnumerable<TransportType> GetAll()
        {
            return _dbContext.TransportType;
        }

        public void Add(TransportType item)
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
    }
}
