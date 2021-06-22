using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
{
    class TripTransportConfiguration : IEntityTypeConfiguration<TripTransport>
    {
        public void Configure(EntityTypeBuilder<TripTransport> builder)
        {
            builder.HasKey(tt => tt.Id);
            builder.HasAlternateKey(tt => new { tt.TripId, tt.TransportId });
            builder.HasOne<Trip>(tt => tt.Trip)
                   .WithMany(t => t.TripTransports)
                   .HasForeignKey(tt => tt.TripId)
                   .IsRequired();
            builder.HasOne<Transport>(tt => tt.Transport)
                   .WithMany(t => t.TripTransports)
                   .HasForeignKey(tt => tt.TransportId)
                   .IsRequired();
            builder.ToTable("trip_transport");
        }
    }
}
