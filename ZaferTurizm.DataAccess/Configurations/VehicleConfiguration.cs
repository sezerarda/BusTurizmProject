using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PlateNumber).IsRequired().HasColumnType("Varchar(20)");
            builder.HasOne(x => x.VehicleDefinition)
                .WithMany()
                .HasForeignKey(x => x.VehicleDefinitionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Vehicle() { Id = 1, PlateNumber = "34 DF 312", VehicleDefinitionId = 1 },
                new Vehicle() { Id = 2, PlateNumber = "16 CG 777", VehicleDefinitionId = 1 },
                new Vehicle() { Id = 3, PlateNumber = "06 AB 312", VehicleDefinitionId = 2 },
                new Vehicle() { Id = 4, PlateNumber = "34 AG 312", VehicleDefinitionId = 3 },
                new Vehicle() { Id = 5, PlateNumber = "37 GF 312", VehicleDefinitionId = 3 },
                new Vehicle() { Id = 6, PlateNumber = "58 DD 312", VehicleDefinitionId = 1 },
                new Vehicle() { Id = 7, PlateNumber = "17 BC 16", VehicleDefinitionId = 5 }
                );
        }
    }
}
