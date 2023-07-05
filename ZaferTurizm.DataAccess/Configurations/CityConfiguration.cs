using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));
            builder.HasKey(x => x.Id);
            builder.Property(city => city.Name).IsRequired().HasColumnType("varchar(50)");

            builder.HasData(
                CityData.Data01_Adana,
                CityData.Data07_Ankara,
                CityData.Data08_Antalya,
                CityData.Data40_İstanbul,
                CityData.Data41_İzmir,
                CityData.Data21_Bursa,
                CityData.Data22_Çanakkale
                );
        }
    }
}
