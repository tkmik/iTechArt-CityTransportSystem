using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
{
    class StopRouteTripConfiguration : IEntityTypeConfiguration<StopRouteTrip>
    {
        public void Configure(EntityTypeBuilder<StopRouteTrip> builder)
        {
            builder.HasKey(srt => srt.Id);
            builder.HasAlternateKey(srt => new { srt.StopRouteId, srt.TripId });
            builder.HasOne<StopRoute>(srt => srt.StopRoutes)
                   .WithMany(sr => sr.StopRouteTrips)
                   .HasForeignKey(srt => srt.StopRouteId)
                   .IsRequired();
            builder.HasOne<Trip>(srt => srt.Trip)
                   .WithMany(t => t.StopRouteTrips)
                   .HasForeignKey(srt => srt.StopRouteId)
                   .IsRequired();
            builder.ToTable("stop_route_trip");
        }
    }
}