﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.Entities
{
    public class Transport
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string PlateNumber { get; set; }
        public DateTime ProductionYear { get; set; }
        public DateTime InspectionYear { get; set; }
        public string FuelType { get; set; }
        public float FuelConsumptionPer100km { get; set; }
        public byte StatusDecommissioned { get; set; }

        public int TransportTypeId { get; set; }
        public TransportType TransportType { get; set; }

        public ICollection<TripTransport> TripTransports { get; set; }
        public ICollection<TripValidation> TripValidations { get; set; }
    }
}
