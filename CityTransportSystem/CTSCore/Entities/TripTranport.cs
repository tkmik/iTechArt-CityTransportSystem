using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    class TripTranport
    {
        public int Id { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
