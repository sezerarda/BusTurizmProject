using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class SeatDto
    {
        public int SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public bool IsSold { get; set; }
    }
}
