using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class __BusTripService : __IBusTripService
    {
        private readonly TourDbContext _tourDbContext;

        public __BusTripService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }

        
        public CommandResult Create(BusTripDto model)
        {
            try
            {
                var busEntity = new BusTrip()
                {
                    Date = model.Date,
                    Price = model.Price,
                    VehicleId = model.VehicleId,
                    VehicleRouteId = model.VehicleRouteId
                };
                _tourDbContext.BusTrips.Add(busEntity);
                _tourDbContext.SaveChanges();

                return CommandResult.Success();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public CommandResult Delete(BusTripDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusTripDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public BusTripDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CommandResult Update(BusTripDto model)
        {
            throw new NotImplementedException();
        }
    }
}
