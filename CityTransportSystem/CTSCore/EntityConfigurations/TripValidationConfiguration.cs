using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTSCore.EntityConfigurations
{
    class TripValidationConfiguration : IEntityTypeConfiguration<TripValidation>
    {
        public void Configure(EntityTypeBuilder<TripValidation> builder)
        {
            builder.HasKey(tv => tv.Id);
            builder.Property(tv => tv.ValidationTime)
                   .IsRequired();
            builder.ToTable("trip_validation");
        }
    }
}