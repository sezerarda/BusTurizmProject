using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class VehicleRouteSummary
    {
        public int Id { get; set; }
        public string DepartureName { get; set; }
        public string ArrivalName { get; set; }
        public string RouteName { get { return DepartureName + "->" + ArrivalName; } }
    }
}
