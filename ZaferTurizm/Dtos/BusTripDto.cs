using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class BusTripDto
    {
        public int Id { get; set; }
        public int VehicleRouteId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; } // Geçmişi gösterme
        public decimal Price { get; set; }

    
    }
}
