using System;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class TripValidationDto
    {
        public int Id { get; set; }
        public DateTime ValidationTime { get; set; }

        public int TransportId { get; set; }
        public TransportDto Transport { get; set; }

        public int[] TicketsId { get; set; }
        public ICollection<TicketDto> Tickets { get; set; }
    }
}
