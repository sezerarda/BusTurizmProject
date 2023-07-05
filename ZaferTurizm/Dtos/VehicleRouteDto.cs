using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class VehicleRouteDto
    {
        public int Id { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
  
    }
}
