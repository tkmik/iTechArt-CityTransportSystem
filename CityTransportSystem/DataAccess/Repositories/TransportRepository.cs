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

        public IEnumerable<Transport> GetAll()
        {
            return _dbContext.Transport;
        }

        public void Add(Transport item)
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
    }
}
