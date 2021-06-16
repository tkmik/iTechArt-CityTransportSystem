using CTSCore.Entities;
using CTSCore.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CTSCore.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Route> Route { get; set; }
        public DbSet<Stop> Stop { get; set; }
        public DbSet<StopRoute> StopRoute { get; set; }
        public DbSet<StopRouteTrip> StopRouteTrip { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<TransportType> TransportType { get; set; }
        public DbSet<TransportTypeStop> TransportTypeStop { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<TripTransport> TripTransport { get; set; }
        public DbSet<TripValidation> TripValidation { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

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
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new StopConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new TransportConfiguration());
            modelBuilder.ApplyConfiguration(new TransportTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TripConfiguration());
            modelBuilder.ApplyConfiguration(new TripValidationConfiguration());
            modelBuilder.ApplyConfiguration(new StopRouteConfiguration());
            modelBuilder.ApplyConfiguration(new StopRouteTripConfiguration());
            modelBuilder.ApplyConfiguration(new TransportTypeStopConfiguration());
            modelBuilder.ApplyConfiguration(new TripTransportConfiguration());           
        }
    }
}
