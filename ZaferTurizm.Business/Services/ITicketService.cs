using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface ITicketService : IBaseService<TicketDto, TicketSummary>
    {
        IEnumerable<TicketDto> GetReservedSeats(int busTripId);

        TicketDto GetTicketById(int ticketId);
        //TicketDto GetTicketByNumber(int ticketNumber);
        //IEnumerable<TicketSummary> GetTicketById(int id);
    }
}
