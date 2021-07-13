using DataAccess.Entities;
using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class RouteViewModel
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string Season { get; set; }

        public int[] TripsId { get; set; }
        public ICollection<TripViewModel> Trips { get; set; }
        public int[] StopRoutesId { get; set; }
        public ICollection<StopRoute> StopRoutes { get; set; }
    }
}
