using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
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