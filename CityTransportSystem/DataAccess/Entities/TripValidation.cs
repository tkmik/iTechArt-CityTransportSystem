using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class TripValidation
    {
        public int Id { get; set; }
        public DateTime ValidationTime { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
