using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.Configurations;
using ZaferTurizm.DataAccess.Settings;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess
{
    public class TourDbContext : DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleDefinition> VehicleDefinitions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleRoute> VehicleRoutes { get; set; }
        public DbSet<BusTrip> BusTrips { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMakeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelSeedData());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleDefinitionSeedData());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new BusTripConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.DbConnectionHomeString);
        }

        
    }
}
