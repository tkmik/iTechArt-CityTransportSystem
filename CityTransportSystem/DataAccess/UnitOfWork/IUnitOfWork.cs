using DataAccess.Entities;
using DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Route> RouteRepository { get; }
        IGenericRepository<Stop> StopRepository { get; }
        IGenericRepository<Ticket> TicketRepository { get; }
        IGenericRepository<Transport> TransportRepository { get; }
        IGenericRepository<TransportType> TransportTypeRepository { get; }
        IGenericRepository<Trip> TripRepository { get; }
        IGenericRepository<TripValidation> TripValidationRepository { get; }
        void Save();
    }
}
