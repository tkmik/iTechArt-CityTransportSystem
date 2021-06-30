using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Route> RouteRepository => new RouteRepository(_context);

        public IGenericRepository<Stop> StopRepository => new StopRepository(_context);

        public IGenericRepository<Ticket> TicketRepository => new TicketRepository(_context);

        public IGenericRepository<Transport> TransportRepository => new TransportRepository(_context);

        public IGenericRepository<TransportType> TransportTypeRepository => new TransportTypeRepository(_context);

        public IGenericRepository<Trip> TripRepository => new TripRepository(_context);

        public IGenericRepository<TripValidation> TripValidationRepository => new TripValidationRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
