﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class VehicleRoute : IEntity
    {
        public int Id { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public string Description { get; set; }
        public City DepartureCity { get; set; }
        public City ArrivalCity { get; set; }
    }
}
