using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    class StopRoute
    {
        public int Id { get; set; }

        public int StopId { get; set; }
        public Stop Stop { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public ICollection<StopRouteTrip> StopRouteTrips { get; set; }
    }
}
