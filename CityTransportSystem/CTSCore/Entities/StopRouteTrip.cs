using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    class StopRouteTrip
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int StopRouteId { get; set; }
        public StopRoute StopRoutes { get; set; }
        

    }
}
