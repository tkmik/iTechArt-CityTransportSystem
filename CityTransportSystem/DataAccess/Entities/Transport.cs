﻿using System;
using System.Collections.Generic;

namespace DataAccess.Entities
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
        public virtual TransportType TransportType { get; set; }

        public virtual ICollection<TripTransport> TripTransports { get; set; }
        public virtual ICollection<TripValidation> TripValidations { get; set; }
    }
}
