using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coordinate { get; set; }
        public string Address { get; set; }

        public ICollection<StopRoute> StopRoutes { get; set; }
        public ICollection<TransportTypeStop> TransportTypeStops { get; set; }
    }
}
