using DataAccess.Entities;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class TransportTypeDto
    {
        public int Id { get; set; }
        public string TransportTypeName { get; set; }

        public int[] TransportsId { get; set; }
        public ICollection<TransportDto> Transports { get; set; }
        public int[] TransportTypeStopsId { get; set; }
        public ICollection<TransportTypeStop> TransportTypeStops { get; set; }
    }
}
