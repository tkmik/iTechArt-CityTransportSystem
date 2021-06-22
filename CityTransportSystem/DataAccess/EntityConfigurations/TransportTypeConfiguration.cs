using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
{
    class TransportTypeConfiguration : IEntityTypeConfiguration<TransportType>
    {
        public void Configure(EntityTypeBuilder<TransportType> builder)
        {
            builder.HasKey(tt => tt.Id);
            builder.Property(tt => tt.TransportTypeName)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.ToTable("transport_type");
        }
    }
}