using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class TransportDto
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
        public TransportTypeDto TransportType { get; set; }
        public ICollection<TripTransport> TripTransports { get; set; }
        public ICollection<TripValidationDto> TripValidations { get; set; }
    }
}
