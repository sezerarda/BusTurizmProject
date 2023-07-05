using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Dtos
{
    public class TicketSummary
    {
        public int Id { get; set; }
        public int TicketNumber { get; set; }
        public int BusTripId { get; set; }
       
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        

        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerIdentityNumber { get; set; }
    }
}
