using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IBusTripService : IBaseService<BusTripDto, BusTripSummary>
    {
        IEnumerable<BusTripSummary> GetTripsWithRouteId(int id);
        BusTripDetails GetBusTripDetails(int id);
        IEnumerable<int> GetSoldSeatNumbers(int busTripId);
    }
}
