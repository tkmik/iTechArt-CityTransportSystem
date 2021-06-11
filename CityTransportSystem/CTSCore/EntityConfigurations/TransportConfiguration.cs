using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
{
    class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasAlternateKey(t => t.Vin);
            builder.Property(t => t.Vin)
                   .HasMaxLength(17)
                   .IsRequired();
            builder.HasAlternateKey(t => t.PlateNumber);
            builder.Property(t => t.PlateNumber)
                   .HasMaxLength(8)
                   .IsRequired();
            builder.Property(t => t.ProductionYear)
                   .IsRequired();
            builder.Property(t => t.InspectionYear)
                   .IsRequired();
            builder.Property(t => t.FuelType)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(t => t.FuelConsumptionPer100km)
                   .IsRequired();
            builder.Property(t => t.StatusDecommissioned)
                   .IsRequired();
            builder.ToTable("transport");
        }
    }
}
