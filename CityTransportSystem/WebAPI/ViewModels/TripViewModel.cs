using DataAccess.Entities;
using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public string TripName { get; set; }

        public int RouteId { get; set; }
        public RouteViewModel Route { get; set; }

        public int[] StopRouteTripsId { get; set; }
        public ICollection<StopRouteTrip> StopRouteTrips { get; set; }
        public int[] TripTransportsId { get; set; }
        public ICollection<TripTransport> TripTransports { get; set; }
    }
}
