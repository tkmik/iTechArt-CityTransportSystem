using DataAccess.Entities;
using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class StopViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coordinate { get; set; }
        public string Address { get; set; }

        public int[] StopRoutesId { get; set; }
        public ICollection<StopRoute> StopRoutes { get; set; }
        public int[] TransportTypeStopsId { get; set; }
        public ICollection<TransportTypeStop> TransportTypeStops { get; set; }
    }
}
