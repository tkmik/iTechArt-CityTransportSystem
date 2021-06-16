using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string Season { get; set; }

        public ICollection<Trip> Trips { get; set; }
        public ICollection<StopRoute> StopRoutes { get; set; }
    }
}
