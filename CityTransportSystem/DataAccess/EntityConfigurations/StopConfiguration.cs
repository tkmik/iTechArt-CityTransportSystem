using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTSCore.EntityConfigurations
{
    class StopConfiguration : IEntityTypeConfiguration<Stop>
    {
        public void Configure(EntityTypeBuilder<Stop> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(s => s.Coordinate)
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(s => s.Address)
                .HasMaxLength(25)
                .IsRequired();
            builder.ToTable("stop");
        }
    }
}