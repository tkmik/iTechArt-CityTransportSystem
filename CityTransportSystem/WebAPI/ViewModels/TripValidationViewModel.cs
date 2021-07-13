using System;
using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class TripValidationViewModel
    {
        public int Id { get; set; }
        public DateTime ValidationTime { get; set; }

        public int TransportId { get; set; }
        public TransportViewModel Transport { get; set; }

        public int[] TicketsId { get; set; }
        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}
