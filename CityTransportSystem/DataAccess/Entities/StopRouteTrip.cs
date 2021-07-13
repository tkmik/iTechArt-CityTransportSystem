using System;

namespace DataAccess.Entities
{
    public class StopRouteTrip
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        public int StopRouteId { get; set; }
        public virtual StopRoute StopRoutes { get; set; }


    }
}
