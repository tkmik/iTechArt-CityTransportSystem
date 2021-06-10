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

        public int StopsRouteId { get; set; }
        public StopRoute StopsRoutes { get; set; }
        

    }
}
