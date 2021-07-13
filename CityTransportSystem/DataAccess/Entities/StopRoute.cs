using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class StopRoute
    {
        public int Id { get; set; }

        public int StopId { get; set; }
        public virtual Stop Stop { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        public virtual ICollection<StopRouteTrip> StopRouteTrips { get; set; }
    }
}
