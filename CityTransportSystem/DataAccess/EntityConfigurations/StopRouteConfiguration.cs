using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    class StopRouteConfiguration : IEntityTypeConfiguration<StopRoute>
    {
        public void Configure(EntityTypeBuilder<StopRoute> builder)
        {
            builder.HasKey(sr => sr.Id);
            builder.HasAlternateKey(sr => new { sr.StopId, sr.RouteId });
            builder.HasOne<Route>(sr => sr.Route)
                   .WithMany(r => r.StopRoutes)
                   .HasForeignKey(sr => sr.RouteId)
                   .IsRequired();
            builder.HasOne<Stop>(sr => sr.Stop)
                   .WithMany(s => s.StopRoutes)
                   .HasForeignKey(sr => sr.StopId)
                   .IsRequired();
            builder.ToTable("stop_route");
        }
    }
}