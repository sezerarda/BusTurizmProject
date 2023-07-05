using System;
using System.Collections.Generic;
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
    public class VehicleRouteService : BaseService<VehicleRouteDto, VehicleRouteSummary, VehicleRoute>, IVehicleRouteService
    {
        public VehicleRouteService(TourDbContext dbContext, GenericValidator<VehicleRoute> validator) : base(dbContext, validator)
        {
        }

        protected override Expression<Func<VehicleRoute, VehicleRouteDto>> DtoMapper =>
            entity => new VehicleRouteDto()
            {
                Id = entity.Id,
                ArrivalCityId = entity.ArrivalCityId,
                DepartureCityId = entity.DepartureCityId,
                
            };

        protected override Expression<Func<VehicleRoute, VehicleRouteSummary>> SummaryMapper =>
            entity => new VehicleRouteSummary()
            {
                Id = entity.Id,
                DepartureName = entity.DepartureCity.Name,
                ArrivalName = entity.ArrivalCity.Name

            };

        protected override VehicleRoute MapToEntity(VehicleRouteDto dto)
        {
            return new VehicleRoute()
            {
                Id = dto.Id,
                DepartureCityId = dto.DepartureCityId,
                ArrivalCityId = dto.ArrivalCityId,
               
            };
        }
    }
}
