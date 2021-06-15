using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
{
    class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TripName)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.ToTable("trip");
        }
    }
}
