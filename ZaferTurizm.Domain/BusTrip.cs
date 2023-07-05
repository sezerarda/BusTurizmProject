using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class BusTrip : IEntity
    {
        public int Id { get; set; }
        public int VehicleRouteId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; } // Geçmişi gösterme
        public decimal Price { get; set; }

        // Navigation Property
        public Vehicle Vehicle { get; set; }
        public VehicleRoute VehicleRoute { get; set; }
    }
}
