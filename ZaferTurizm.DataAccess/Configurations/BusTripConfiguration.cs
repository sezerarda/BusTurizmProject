using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class BusTripConfiguration : IEntityTypeConfiguration<BusTrip>
    {
        public void Configure(EntityTypeBuilder<BusTrip> builder)
        {
            builder.ToTable(nameof(BusTrip));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).IsRequired().HasColumnType("datetime2(0)");
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal");

            builder.HasOne(x => x.VehicleRoute)
                .WithMany()
                .HasForeignKey(x => x.VehicleRouteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Vehicle)
                .WithMany()
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new BusTrip()
            {
                Id = 1,
                Price = 100,
                Date = DateTime.Parse("2023 - 07 - 06"),
                VehicleRouteId = 1,
                VehicleId = 1,
            });

         
        }
    }
}
