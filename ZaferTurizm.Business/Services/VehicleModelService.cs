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
    public class VehicleModelService : BaseService<VehicleModelDto, VehicleModelSummary, VehicleModel>, IVehicleModelService
    {
        public VehicleModelService(TourDbContext dbContext, GenericValidator<VehicleModel> validator) : base(dbContext, validator)
        {
        }

        protected override Expression<Func<VehicleModel, VehicleModelDto>> DtoMapper => 
            entity => new VehicleModelDto() 
            {
                Id = entity.Id,
                Name = entity.Name,
                VehicleMakeId = entity.VehicleMakeId
            };

        protected override Expression<Func<VehicleModel, VehicleModelSummary>> SummaryMapper =>
            entity => new VehicleModelSummary()
            {
                Id = entity.Id,
                Name = entity.Name,
                VehicleMakeName = entity.VehicleMake.Name
            };

        public IEnumerable<VehicleModelDto> GetByMakeId(int MakeId)
        {
            try
            {
                return _dbContext.VehicleModels
                    .Where(x => x.VehicleMakeId == MakeId)
                    .Select(DtoMapper)
                    .ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelDto>();
            }
        }

        protected override VehicleModel MapToEntity(VehicleModelDto dto)
        {
           var entity = new VehicleModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                VehicleMakeId = dto.VehicleMakeId
            };

            return entity;
        }
    }
}
