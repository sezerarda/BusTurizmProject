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
    public class VehicleService : BaseService<VehicleDto, VehicleSummary, Vehicle>, IVehicleService
    {
        public VehicleService(TourDbContext dbContext, GenericValidator<Vehicle> validator) : base(dbContext, validator)
        {
        }

        protected override Expression<Func<Vehicle, VehicleDto>> DtoMapper => 
            entity => new VehicleDto() 
            { 
                Id = entity.Id,
                PlateNumber = entity.PlateNumber,
                VehicleDefinitionId = entity.VehicleDefinitionId
            };

        protected override Expression<Func<Vehicle, VehicleSummary>> SummaryMapper =>
            entity => new VehicleSummary()
            {
                Id = entity.Id,
                PlateNumber = entity.PlateNumber,
                VehicleDefinitionSeatCount = entity.VehicleDefinition.SeatCount,
                VehicleDefinitionToilet = entity.VehicleDefinition.HasToilet,
                VehicleDefinitionWifi = entity.VehicleDefinition.HasWifi,
                VehicleDefinitionYear = entity.VehicleDefinition.Year,
                VehicleModelName = entity.VehicleDefinition.VehicleModel.Name,
                VehicleMakeName = entity.VehicleDefinition.VehicleModel.VehicleMake.Name
            };

        protected override Vehicle MapToEntity(VehicleDto dto)
        {
            return new Vehicle()
            {
                Id = dto.Id,
                PlateNumber = dto.PlateNumber,
                VehicleDefinitionId = dto.VehicleDefinitionId
            };
        }
    }
}
