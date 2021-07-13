using DataAccess.Entities;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string Season { get; set; }

        public int[] TripsId { get; set; }
        public ICollection<TripDto> Trips { get; set; }
        public int[] StopRoutesId { get; set; }
        public ICollection<StopRoute> StopRoutes { get; set; }
    }
}
