using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class TransportType
    {
        public int Id { get; set; }
        public string TransportTypeName { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }
        public virtual ICollection<TransportTypeStop> TransportTypeStops { get; set; }
    }
}
