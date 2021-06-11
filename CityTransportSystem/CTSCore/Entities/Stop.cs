using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
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
