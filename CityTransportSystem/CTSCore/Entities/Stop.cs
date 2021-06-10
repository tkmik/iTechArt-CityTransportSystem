using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coordinate { get; set; }
        public string Address { get; set; }

        public ICollection<StopRoute> StopsRoutes { get; set; }
        public ICollection<TransportTypeStop> TransportTypesStops { get; set; }
    }
}
