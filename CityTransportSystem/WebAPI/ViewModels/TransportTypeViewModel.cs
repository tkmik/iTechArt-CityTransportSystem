using DataAccess.Entities;
using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class TransportTypeViewModel
    {
        public int Id { get; set; }
        public string TransportTypeName { get; set; }

        public int[] TransportsId { get; set; }
        public ICollection<TransportViewModel> Transports { get; set; }
        public int[] TransportTypeStopsId { get; set; }
        public ICollection<TransportTypeStop> TransportTypeStops { get; set; }
    }
}
