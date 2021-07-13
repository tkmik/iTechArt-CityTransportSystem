using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public string TripName { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        public virtual ICollection<StopRouteTrip> StopRouteTrips { get; set; }
        public virtual ICollection<TripTransport> TripTransports { get; set; }
    }
}
