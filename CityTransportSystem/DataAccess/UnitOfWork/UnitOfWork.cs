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

        private IGenericRepository<Route> _routeRepository;
        private IGenericRepository<Stop> _stopRepository;
        private IGenericRepository<Ticket> _ticketRepository;
        private IGenericRepository<Transport> _transportRepository;
        private IGenericRepository<TransportType> _transportTypeRepository;
        private IGenericRepository<Trip> _tripRepository;
        private IGenericRepository<TripValidation> _tripValidationRepository;

        IGenericRepository<Route> IUnitOfWork.RouteRepository
        {
            get
            {
                if (_routeRepository is null)
                {
                    _routeRepository = new RouteRepository(_context);
                }
                return _routeRepository;
            }
        }

        IGenericRepository<Stop> IUnitOfWork.StopRepository
        {
            get
            {
                if (_stopRepository is null)
                {
                    _stopRepository = new StopRepository(_context);
                }
                return _stopRepository;
            }
        }

        IGenericRepository<Ticket> IUnitOfWork.TicketRepository
        {
            get
            {
                if (_ticketRepository is null)
                {
                    _ticketRepository = new TicketRepository(_context);
                }
                return _ticketRepository;
            }
        }

        IGenericRepository<Transport> IUnitOfWork.TransportRepository
        {
            get
            {
                if (_transportRepository is null)
                {
                    _transportRepository = new TransportRepository(_context);
                }
                return _transportRepository;
            }
        }

        IGenericRepository<TransportType> IUnitOfWork.TransportTypeRepository
        {
            get
            {
                if (_transportTypeRepository is null)
                {
                    _transportTypeRepository = new TransportTypeRepository(_context);
                }
                return _transportTypeRepository;
            }
        }

        IGenericRepository<Trip> IUnitOfWork.TripRepository
        {
            get
            {
                if (_tripRepository is null)
                {
                    _tripRepository = new TripRepository(_context);
                }
                return _tripRepository;
            }
        }

        IGenericRepository<TripValidation> IUnitOfWork.TripValidationRepository
        {
            get
            {
                if (_tripValidationRepository is null)
                {
                    _tripValidationRepository = new TripValidationRepository(_context);
                }
                return _tripValidationRepository;
            }
        }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
