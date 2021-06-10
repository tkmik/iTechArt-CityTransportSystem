using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    class TransportType
    {
        public int Id { get; set; }
        public string TransportTypeName { get; set; }

        public ICollection<Transport> Transports { get; set; }
        public ICollection<TransportTypeStop> TransportTypesStops { get; set; }
    }
}
