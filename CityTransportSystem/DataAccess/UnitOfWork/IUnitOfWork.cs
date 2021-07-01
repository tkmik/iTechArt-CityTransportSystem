using DataAccess.Entities;
using DataAccess.GenericRepository;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRouteRepository RouteRepository { get; }
        IStopRepository StopRepository { get; }
        ITicketRepository TicketRepository { get; }
        ITransportRepository TransportRepository { get; }
        ITransportTypeRepository TransportTypeRepository { get; }
        ITripRepository TripRepository { get; }
        ITripValidationRepository TripValidationRepository { get; }
        void Save();
    }
}
