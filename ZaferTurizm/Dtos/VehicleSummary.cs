using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class VehicleSummary
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public int VehicleDefinitionYear { get; set; }
        public int VehicleDefinitionSeatCount { get; set; }

        public string VehicleDescription
        {
            get
            {
                return PlateNumber + " " + VehicleMakeName + " " + VehicleModelName;
            }
        }


        // Bu yöntem de diğer şekilde yapılan bir yöntem.
        public bool VehicleDefinitionToilet { get; set; }
        public string VehicleDefinitionToiletString
        {
            get
            {
                return VehicleDefinitionToilet ? "Var" : "Yok";
            }
        }

        public bool VehicleDefinitionWifi { get; set; }

        // Bool değeri String değere dçnüştürme. Summary kısmında bool olan değeri string olarak göstermek istersem böyle yapabilirim
        public string VehicleDefinitionWifiString => VehicleDefinitionWifi ? "Var" : "Yok";
    }
}
