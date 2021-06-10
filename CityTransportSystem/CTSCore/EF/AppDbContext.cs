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
        public DbSet<TripTranport> TripTranports { get; set; }
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
                             .HasMaxLength(25)
                             .IsRequired();
                        route.Property(r => r.Season)
                             .HasMaxLength(15)
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
                            .HasMaxLength(25)
                            .IsRequired();
                        stop.Property(s => s.Coordinate)
                            .HasMaxLength(50)
                            .IsRequired();
                        stop.Property(s => s.Address)
                            .HasMaxLength(25)
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
                        transport.HasAlternateKey(t => t.VIN);
                        transport.HasAlternateKey(t => t.PlateNumber);
                        transport.Property(t => t.ProductionYear)
                                 .IsRequired();
                        transport.Property(t => t.InspectionYear)
                                 .IsRequired();
                        transport.Property(t => t.FuelType)
                                 .HasMaxLength(15)
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
                    transporttype => 
                    {
                        transporttype.HasKey(tt => tt.Id);
                        transporttype.Property(tt => tt.TransportTypeName)
                                     .HasMaxLength(25)
                                     .IsRequired();
                    }
                );

            //Entity Trip
            modelBuilder.Entity<Trip>
                (
                    trip => {
                        trip.HasKey(t => t.Id);
                        trip.Property(t => t.TripName)
                            .HasMaxLength(25)
                            .IsRequired();
                    }
                );

            //Entity TripValidation
            modelBuilder.Entity<TripValidation>
                (
                    tripvalidation => 
                    {
                        tripvalidation.HasKey(tv => tv.Id);
                        tripvalidation.Property(tv => tv.ValidationTime)
                                      .IsRequired();
                    }
                );

            //many-to-many StopRoute
            modelBuilder.Entity<StopRoute>
                (
                    stoproute => 
                    {
                        stoproute.HasKey(sr => sr.Id);
                        stoproute.HasAlternateKey(sr => new { sr.StopId, sr.RouteId });
                        stoproute.HasOne<Route>(sr => sr.Route)
                                 .WithMany(r => r.StopRoutes)
                                 .HasForeignKey(sr => sr.RouteId)
                                 .IsRequired();
                        stoproute.HasOne<Stop>(sr => sr.Stop)
                                 .WithMany(s => s.StopsRoutes)
                                 .HasForeignKey(sr => sr.StopId)
                                 .IsRequired();
                    }
                );

            //many-to-many StopRouteTrip
            modelBuilder.Entity<StopRouteTrip>
                (
                    stoproutetrip => 
                    {
                        stoproutetrip.HasKey(srt => srt.Id);
                        stoproutetrip.HasAlternateKey(srt => new { srt.StopsRouteId, srt.TripId });
                        stoproutetrip.HasOne<StopRoute>(srt => srt.StopsRoutes)
                                     .WithMany(sr => sr.StopsRoutesTrips)
                                     .HasForeignKey(srt => srt.StopsRouteId)
                                     .IsRequired();
                        stoproutetrip.HasOne<Trip>(srt => srt.Trip)
                                     .WithMany(t => t.StopsRoutesTrips)
                                     .HasForeignKey(srt => srt.StopsRouteId)
                                     .IsRequired();
                    }
                );

            //many-to-manty TransportTypeStop
            modelBuilder.Entity<TransportTypeStop>
                (
                    transporttypestop => 
                    {
                        transporttypestop.HasKey(tts => tts.Id);
                        transporttypestop.HasAlternateKey(tts => new { tts.TransportTypeId, tts.StopId });
                        transporttypestop.HasOne<TransportType>(tts => tts.TransportType)
                                         .WithMany(tt => tt.TransportTypesStops)
                                         .HasForeignKey(tts => tts.TransportTypeId)
                                         .IsRequired();
                        transporttypestop.HasOne<Stop>(tts => tts.Stop)
                                         .WithMany(s => s.TransportTypesStops)
                                         .HasForeignKey(tts => tts.TransportTypeId)
                                         .IsRequired();
                    }
                );

            //many-to-many TripTransport
            modelBuilder.Entity<TripTranport>
                (
                    triptrancport => 
                    {
                        triptrancport.HasKey(tt => tt.Id);
                        triptrancport.HasAlternateKey(tt => new { tt.TripId, tt.TransportId });
                        triptrancport.HasOne<Trip>(tt => tt.Trip)
                                     .WithMany(t => t.TripsTranports)
                                     .HasForeignKey(tt => tt.TripId)
                                     .IsRequired();
                        triptrancport.HasOne<Transport>(tt => tt.Transport)
                                     .WithMany(t => t.TripTranports)
                                     .HasForeignKey(tt => tt.TransportId)
                                     .IsRequired();
                    }
                );            
        }
    }
}
