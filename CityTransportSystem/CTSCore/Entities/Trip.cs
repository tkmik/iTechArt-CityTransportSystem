using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public string TripName { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public ICollection<StopRouteTrip> StopRouteTrips { get; set; }
        public ICollection<TripTransport> TripTransports { get; set; }
    }
}
