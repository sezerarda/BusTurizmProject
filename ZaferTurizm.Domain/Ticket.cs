using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int TicketNumber { get; set; }
        public int BusTripId { get; set; }
        public int CustomerId { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool seatStatus { get; set; }

        public BusTrip BusTrip { get; set; }
        public Customer Customer { get; set; }



        //public int BusNumber { get; set; }
        //public string PersonName { get; set; }
        //public string Time { get; set; }
        //public DateTime Date { get; set; }
        //public string Title { get; set; }
    }
}
