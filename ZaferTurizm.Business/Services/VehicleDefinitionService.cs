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
    public class VehicleDefinitionService : BaseService<VehicleDefinitionDto, VehicleDefinitionSummary, VehicleDefinition>, IVehicleDefinitionService
    {
        public VehicleDefinitionService(TourDbContext dbContext, GenericValidator<VehicleDefinition> validator) : base(dbContext, validator)
        {
        }

        protected override Expression<Func<VehicleDefinition, VehicleDefinitionDto>> DtoMapper =>
            entity => new VehicleDefinitionDto()
            {
                Id = entity.Id,
                HasToilet = entity.HasToilet,
                HasWifi = entity.HasWifi,
                SeatCount = entity.SeatCount,
                Year = entity.Year,
                VehicleMakeId = entity.VehicleModel.VehicleMakeId,
                VehicleModelId = entity.VehicleModelId
            };

        protected override Expression<Func<VehicleDefinition, VehicleDefinitionSummary>> SummaryMapper =>
            entity => new VehicleDefinitionSummary()
            {
                Id = entity.Id,
                Year = entity.Year,
                SeatCount = entity.SeatCount,
                HasWifi = entity.HasWifi,
                HasToilet = entity.HasToilet,
                VehicleMakeName = entity.VehicleModel.VehicleMake.Name,
                VehicleModelName = entity.VehicleModel.Name
            };

        protected override VehicleDefinition MapToEntity(VehicleDefinitionDto dto)
        {
            return new VehicleDefinition()
            {
                Id = dto.Id,
                Year = dto.Year,
                SeatCount = dto.SeatCount,
                HasToilet = dto.HasToilet,
                HasWifi = dto.HasWifi,
                VehicleModelId = dto.VehicleModelId
            };
        }
    }
}
