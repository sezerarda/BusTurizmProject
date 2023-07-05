using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public class RouteData
    {
        public static readonly VehicleRoute Data01_IzmirIstanbul = new VehicleRoute()
        {
            Id = 1,
            DepartureCityId = CityData.Data41_İzmir.Id,
            ArrivalCityId = CityData.Data40_İstanbul.Id,
            Description = "Açıklama 1"
        };

        public static readonly VehicleRoute Data02_IstanbulAntalya = new VehicleRoute()
        {
            Id = 2,
            DepartureCityId = CityData.Data40_İstanbul.Id,
            ArrivalCityId = CityData.Data08_Antalya.Id,
            Description = "Açıklama 2"

        };

        public static readonly VehicleRoute Data03_AnkaraAntalya = new VehicleRoute()
        {
            Id = 3,
            DepartureCityId = CityData.Data07_Ankara.Id,
            ArrivalCityId = CityData.Data08_Antalya.Id,
            Description = "Açıklama 3"

        };
        public static readonly VehicleRoute Data03_BursaCanakkale = new VehicleRoute()
        {
            Id = 4,
            DepartureCityId = CityData.Data21_Bursa.Id,
            ArrivalCityId = CityData.Data22_Çanakkale.Id,
            Description = "Açıklama 4"

        };
    }
}
