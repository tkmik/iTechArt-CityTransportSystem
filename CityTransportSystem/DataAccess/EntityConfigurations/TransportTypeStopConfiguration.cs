using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
{
    class TransportTypeStopConfiguration : IEntityTypeConfiguration<TransportTypeStop>
    {
        public void Configure(EntityTypeBuilder<TransportTypeStop> builder)
        {
            builder.HasKey(tts => tts.Id);
            builder.HasAlternateKey(tts => new { tts.TransportTypeId, tts.StopId });
            builder.HasOne<TransportType>(tts => tts.TransportType)
                   .WithMany(tt => tt.TransportTypeStops)
                   .HasForeignKey(tts => tts.TransportTypeId)
                   .IsRequired();
            builder.HasOne<Stop>(tts => tts.Stop)
                   .WithMany(s => s.TransportTypeStops)
                   .HasForeignKey(tts => tts.TransportTypeId)
                   .IsRequired();
            builder.ToTable("transport_type_table");
        }
    }
}