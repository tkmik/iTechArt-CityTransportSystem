using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    public class TransportTypeStop
    {
        public int Id { get; set; }

        public int TransportTypeId { get; set; }
        public TransportType TransportType { get; set; }

        public int StopId { get; set; }
        public Stop Stop { get; set; }
    }
}
