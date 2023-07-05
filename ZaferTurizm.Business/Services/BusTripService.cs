using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Validators;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class BusTripService : BaseService<BusTripDto, BusTripSummary, BusTrip>, IBusTripService
    {
        private readonly ITicketService _ticketService;



        public BusTripService(TourDbContext dbContext, BusTripValidator validator, ITicketService ticketService) : base(dbContext, validator)
        {
            _ticketService = ticketService;
        }

        protected override Expression<Func<BusTrip, BusTripDto>> DtoMapper =>
            entity => new BusTripDto()
            {
                Id = entity.Id,
                Date = entity.Date,
                Price = entity.Price,
                VehicleId = entity.VehicleId,
                VehicleRouteId = entity.VehicleRouteId
                
            };


        protected override Expression<Func<BusTrip, BusTripSummary>> SummaryMapper =>
            entity => new BusTripSummary()
            {
                Id = entity.Id,
                Date = entity.Date,
                Price = entity.Price,
                VehicleModelName = entity.Vehicle.VehicleDefinition.VehicleModel.Name,
                VehicleMakeName = entity.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                VehiclePlate = entity.Vehicle.PlateNumber,
                DepartureName = entity.VehicleRoute.DepartureCity.Name,
                ArrivalName = entity.VehicleRoute.ArrivalCity.Name,
                SeatCount = entity.Vehicle.VehicleDefinition.SeatCount
                
            };
        //Burada emin değilim tekrar kontrol et

        public BusTripDetails? GetBusTripDetails(int id)
        {
            try
            {
                return _dbContext.BusTrips
                    .Where(x => x.Id == id)
                    .Select(x => new BusTripDetails()
                    {
                        BusTripId = x.Id,
                        ArrivalName = x.VehicleRoute.ArrivalCity.Name,
                        DepartureName = x.VehicleRoute.DepartureCity.Name,
                        VehiclePlate = x.Vehicle.PlateNumber,
                        VehicleMakeName = x.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                        VehicleModelName = x.Vehicle.VehicleDefinition.VehicleModel.Name,
                        TicketPrice = x.Price,
                        SeatCount = x.Vehicle.VehicleDefinition.SeatCount,
                        Date = x.Date,
                        SoldSeatNumbers = _dbContext.Tickets
                                        .Where(t => t.Id == id)
                                        .Select(t => t.SeatNumber)
                                        .ToList(),

                        Tickets = _dbContext.Tickets
                                        .Where(t => t.BusTripId == id)
                                        .Select(t => new TicketDto
                                        {
                                            Id = t.Id,
                                            BusTripId = t.BusTripId,
                                            BusTripName = $"{x.Date.ToString("dd.MM.yyyy HH:mm")} / {x.VehicleRoute.DepartureCity.Name} -> {x.VehicleRoute.ArrivalCity.Name}",
                                            SeatNumber = t.SeatNumber,
                                            Price = t.Price,
                                            SeatStatus = true,
                                            CustomerName = t.Customer.Name,
                                            CustomerSurname = t.Customer.Surname,
                                            CustomerIdentityNumber = t.Customer.IdentityNumber
                                        })
                    .ToList()

                        //SoldSeatNumbers = GetSoldSeatNumbers(x.Id).ToList()

                    }).SingleOrDefault();

              
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public IEnumerable<int> GetSoldSeatNumbers(int busTripId)
        {
            var soldSeats = _dbContext.Tickets
            .Where(t => t.BusTripId == busTripId)
            .Select(t => t.SeatNumber)
            .ToList();

            return soldSeats;
        }

        public IEnumerable<BusTripSummary> GetTripsWithRouteId(int id)
        {
            //try
            //{
            //    return _dbContext.BusTrips
            //        .Where(x => x.Id == id)
            //        .Select(SummaryMapper).ToList();
            //}
            //catch (Exception ex)
            //{

            //    Trace.TraceError(ex.ToString());
            //    return Enumerable.Empty<BusTripSummary>();
            //}


            try
            {
                var busTrip = _dbContext.BusTrips
                    .Where(x => x.Id == id)
                    .SingleOrDefault();

                if (busTrip == null)
                {
                    return null;
                }

                //var soldSeatNumbers = _ticketService.GetSoldSeatNumbers(id);

                var busTripDetails = new BusTripDetails
                {
                    BusTripId = busTrip.Id,
                    ArrivalName = busTrip.VehicleRoute.ArrivalCity.Name,
                    DepartureName = busTrip.VehicleRoute.DepartureCity.Name,
                    VehiclePlate = busTrip.Vehicle.PlateNumber,
                    VehicleMakeName = busTrip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                    VehicleModelName = busTrip.Vehicle.VehicleDefinition.VehicleModel.Name,
                    TicketPrice = busTrip.Price,
                    SeatCount = busTrip.Vehicle.VehicleDefinition.SeatCount,
                    Date = busTrip.Date
                    //SoldSeatNumbers = soldSeatNumbers
                };

                return (IEnumerable<BusTripSummary>)busTripDetails;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }

        }


        protected override BusTrip MapToEntity(BusTripDto dto)
        {
            return new BusTrip()
            {
                Id = dto.Id,
                Date = dto.Date,
                Price = dto.Price,
                VehicleRouteId = dto.VehicleRouteId,
                VehicleId = dto.VehicleId
            };
        }
    }
}
