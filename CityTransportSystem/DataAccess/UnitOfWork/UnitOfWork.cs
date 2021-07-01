using DataAccess.EF;
using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;
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
            RouteRepository = new RouteRepository(_context);
            StopRepository = new StopRepository(_context);
            TicketRepository = new TicketRepository(_context);
            TransportRepository = new TransportRepository(_context);
            TransportTypeRepository = new TransportTypeRepository(_context);
            TripRepository = new TripRepository(_context);
            TripValidationRepository = new TripValidationRepository(_context);
        }

        public IRouteRepository RouteRepository { get; }
        public IStopRepository StopRepository { get; }
        public ITicketRepository TicketRepository { get; }
        public ITransportRepository TransportRepository { get; }
        public ITransportTypeRepository TransportTypeRepository { get; }
        public ITripRepository TripRepository { get; }
        public ITripValidationRepository TripValidationRepository { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
