using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class RouteConfiguration : IEntityTypeConfiguration<VehicleRoute>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VehicleRoute> builder)
        {
            builder.ToTable(nameof(VehicleRoute));
            builder.HasKey(route => route.Id);
            

            builder.HasOne(route => route.DepartureCity)
                .WithMany()
                .HasForeignKey(route => route.DepartureCityId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(route => route.ArrivalCity)
                .WithMany()
                .HasForeignKey(route => route.ArrivalCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                RouteData.Data01_IzmirIstanbul,
                RouteData.Data02_IstanbulAntalya,
                RouteData.Data03_AnkaraAntalya,
                RouteData.Data03_BursaCanakkale
                );
        }
    }
}
