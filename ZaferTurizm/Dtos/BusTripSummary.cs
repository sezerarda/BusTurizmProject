using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class BusTripSummary
    {
        public int Id { get; set; }
        public string RouteName
        {
            get
            {
               return DepartureName + " -> " + ArrivalName;
            }
        }
        public DateTime Date { get; set; } // Geçmişi gösterme
        public decimal Price { get; set; }
        public int SeatCount { get; set; }
        public string DepartureName { get; set; }
        public string ArrivalName { get; set; }

        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleName
        {
            get
            {
                return VehicleMakeName + " " + VehicleModelName + " " + VehiclePlate;
            }
        }
     
    }
}
