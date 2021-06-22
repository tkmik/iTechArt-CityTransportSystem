using CTSCore.Entities;
using CTSCore.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

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


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());       
        }
    }
}
