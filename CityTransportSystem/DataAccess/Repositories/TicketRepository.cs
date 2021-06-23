using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly AppDbContext _dbContext;

        public TicketRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Ticket Get(int id)
        {
            return _dbContext.Ticket.Find(id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _dbContext.Ticket;
        }
        public void Add(Ticket item)
        {
            _dbContext.Ticket.Add(item);
        }

        public void Update(Ticket item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Ticket ticket = _dbContext.Ticket.Find(id);
            if (ticket != null)
            {
                _dbContext.Remove(ticket);
            }
        }
    }
}
