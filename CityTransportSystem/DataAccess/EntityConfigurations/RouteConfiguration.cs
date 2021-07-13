using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RouteName)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(r => r.Season)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.ToTable("route");
        }
    }
}
