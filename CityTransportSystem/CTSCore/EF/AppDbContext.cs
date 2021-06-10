using CTSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CTSCore.EF
{
    class AppDbContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<StopRoute> StopRoutes { get; set; }
        public DbSet<StopRouteTrip> StopRouteTrips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<TransportTypeStop> TransportTypeStops { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripTransport> TripTransports { get; set; }
        public DbSet<TripValidation> TripValidations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("PostgreSQL");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Route
            modelBuilder.Entity<Route>
                (
                    route =>
                    {
                        route.HasKey(r => r.Id);
                        route.Property(r => r.RouteName)
                             .HasMaxLength(100)
                             .IsRequired();
                        route.Property(r => r.Season)
                             .HasMaxLength(100)
                             .IsRequired();
                    }
                );
            //Entity Stop
            modelBuilder.Entity<Stop>
                (
                    stop => 
                    {
                        stop.HasKey(s => s.Id);
                        stop.Property(s => s.Name)
                            .HasMaxLength(100)
                            .IsRequired();
                        stop.Property(s => s.Coordinate)
                            .HasMaxLength(100)
                            .IsRequired();
                        stop.Property(s => s.Address)
                            .HasMaxLength(100)
                            .IsRequired();
                    }
                );

            //Entity Ticket
            modelBuilder.Entity<Ticket>
                (
                    ticket => 
                    {
                        ticket.HasKey(t => t.Id);
                        ticket.HasAlternateKey(t => t.SerialNumber);
                        ticket.Property(t => t.SerialNumber)
                              .IsRequired();
                        ticket.Property(t => t.Cost)
                              .IsRequired();
                    }
                );

            //Entity Transport
            modelBuilder.Entity<Transport>
                (
                    transport => 
                    {
                        transport.HasKey(t => t.Id);
                        transport.HasAlternateKey(t => t.Vin);
                        transport.Property(t => t.Vin)
                                 .HasMaxLength(17)
                                 .IsRequired();
                        transport.HasAlternateKey(t => t.PlateNumber);
                        transport.Property(t => t.PlateNumber)
                                 .HasMaxLength(8)
                                 .IsRequired();
                        transport.Property(t => t.ProductionYear)
                                 .IsRequired();
                        transport.Property(t => t.InspectionYear)
                                 .IsRequired();
                        transport.Property(t => t.FuelType)
                                 .HasMaxLength(100)
                                 .IsRequired();
                        transport.Property(t => t.FuelConsumptionPer100km)
                                 .IsRequired();
                        transport.Property(t => t.StatusDecommissioned)
                                 .IsRequired();
                    }
                );

            //Entity TransportType
            modelBuilder.Entity<TransportType>
                (
                    transportType => 
                    {
                        transportType.HasKey(tt => tt.Id);
                        transportType.Property(tt => tt.TransportTypeName)
                                     .HasMaxLength(100)
                                     .IsRequired();
                    }
                );

            //Entity Trip
            modelBuilder.Entity<Trip>
                (
                    trip => {
                        trip.HasKey(t => t.Id);
                        trip.Property(t => t.TripName)
                            .HasMaxLength(100)
                            .IsRequired();
                    }
                );

            //Entity TripValidation
            modelBuilder.Entity<TripValidation>
                (
                    tripValidation => 
                    {
                        tripValidation.HasKey(tv => tv.Id);
                        tripValidation.Property(tv => tv.ValidationTime)
                                      .IsRequired();
                    }
                );

            //many-to-many StopRoute
            modelBuilder.Entity<StopRoute>
                (
                    stopRoute => 
                    {
                        stopRoute.HasKey(sr => sr.Id);
                        stopRoute.HasAlternateKey(sr => new { sr.StopId, sr.RouteId });
                        stopRoute.HasOne<Stop>(sr => sr.Stop)
                                .WithMany(s => s.StopRoutes)
                                .HasForeignKey(sr => sr.StopId)
                                .IsRequired();
                        stopRoute.HasOne<Route>(sr => sr.Route)
                                 .WithMany(r => r.StopRoutes)
                                 .HasForeignKey(sr => sr.RouteId)
                                 .IsRequired();                       
                    }
                );

            //many-to-many StopRouteTrip
            modelBuilder.Entity<StopRouteTrip>
                (
                    stopRouteTrip => 
                    {
                        stopRouteTrip.HasKey(srt => srt.Id);
                        stopRouteTrip.HasAlternateKey(srt => new { srt.StopRouteId, srt.TripId });
                        stopRouteTrip.HasOne<StopRoute>(srt => srt.StopRoutes)
                                     .WithMany(sr => sr.StopRouteTrips)
                                     .HasForeignKey(srt => srt.StopRouteId)
                                     .IsRequired();
                        stopRouteTrip.HasOne<Trip>(srt => srt.Trip)
                                     .WithMany(t => t.StopRouteTrips)
                                     .HasForeignKey(srt => srt.StopRouteId)
                                     .IsRequired();
                    }
                );

            //many-to-manty TransportTypeStop
            modelBuilder.Entity<TransportTypeStop>
                (
                    transportTypeStop => 
                    {
                        transportTypeStop.HasKey(tts => tts.Id);
                        transportTypeStop.HasAlternateKey(tts => new { tts.TransportTypeId, tts.StopId });
                        transportTypeStop.HasOne<TransportType>(tts => tts.TransportType)
                                         .WithMany(tt => tt.TransportTypeStops)
                                         .HasForeignKey(tts => tts.TransportTypeId)
                                         .IsRequired();
                        transportTypeStop.HasOne<Stop>(tts => tts.Stop)
                                         .WithMany(s => s.TransportTypeStops)
                                         .HasForeignKey(tts => tts.TransportTypeId)
                                         .IsRequired();
                    }
                );

            //many-to-many TripTransport
            modelBuilder.Entity<TripTransport>
                (
                    tripTransport => 
                    {
                        tripTransport.HasKey(tt => tt.Id);
                        tripTransport.HasAlternateKey(tt => new { tt.TripId, tt.TransportId });
                        tripTransport.HasOne<Trip>(tt => tt.Trip)
                                     .WithMany(t => t.TripTransports)
                                     .HasForeignKey(tt => tt.TripId)
                                     .IsRequired();
                        tripTransport.HasOne<Transport>(tt => tt.Transport)
                                     .WithMany(t => t.TripTransports)
                                     .HasForeignKey(tt => tt.TransportId)
                                     .IsRequired();
                    }
                );            
        }
    }
}
