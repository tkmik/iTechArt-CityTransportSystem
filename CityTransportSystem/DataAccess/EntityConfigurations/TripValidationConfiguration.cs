using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
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