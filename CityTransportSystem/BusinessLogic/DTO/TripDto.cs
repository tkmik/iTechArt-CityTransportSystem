using DataAccess.Entities;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class TripDto
    {
        public int Id { get; set; }
        public string TripName { get; set; }

        public int RouteId { get; set; }
        public RouteDto Route { get; set; }

        public int[] StopRouteTripsId { get; set; }
        public ICollection<StopRouteTrip> StopRouteTrips { get; set; }
        public int[] TripTransportsId { get; set; }
        public ICollection<TripTransport> TripTransports { get; set; }
    }
}
