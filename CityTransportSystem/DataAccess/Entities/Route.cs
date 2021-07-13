using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string Season { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<StopRoute> StopRoutes { get; set; }
    }
}
