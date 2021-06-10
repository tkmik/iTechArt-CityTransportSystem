using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    class Ticket
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public float Cost { get; set; }

        public int TripValidationId { get; set; }
        public TripValidation TripValidation { get; set; }
    }
}
