using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class __VehicleDefinitionService : __IVehicleDefinitionService
    {
        private readonly TourDbContext _dbContext;

        public __VehicleDefinitionService(TourDbContext tourDbContext)
        {
            _dbContext = tourDbContext;
        }

        public CommandResult Create(VehicleDefinitionDto model)
        {
            try
            {
                var entityDefinition = new VehicleDefinition()
                {
                    HasToilet = model.HasToilet,
                    HasWifi = model.HasWifi,
                    SeatCount = model.SeatCount,
                    Year = model.Year,
                    VehicleModelId = model.VehicleModelId

                };

                _dbContext.VehicleDefinitions.Add(entityDefinition);
                _dbContext.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();

            }
        }

        public CommandResult Delete(VehicleDefinitionDto model)
        {

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model null olamaz");
            }
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var entity = new VehicleDefinition() { Id = id };
            try
            {
                _dbContext.VehicleDefinitions.Remove(entity);
                _dbContext.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Bir hata meydana geldi, sistem yöneticisine başvurun");
            }
        }

        public IEnumerable<VehicleDefinitionDto> GetAll()
        {
            try
            {
               return _dbContext.VehicleDefinitions
                    .Select(x => new VehicleDefinitionDto()
                    {
                        Id = x.Id,
                        HasToilet = x.HasToilet,
                        HasWifi = x.HasWifi,
                        SeatCount = x.SeatCount,
                        Year = x.Year,
                        VehicleModelId = x.VehicleModel.Id,
                        VehicleMakeId = x.VehicleModel.VehicleMake.Id
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDefinitionDto>();

            }
        }

        public VehicleDefinitionDto? GetById(int id)
        {
            try
            {
                return _dbContext.VehicleDefinitions
                    .Select(entity => new VehicleDefinitionDto()
                    {
                        Id = entity.Id,
                        VehicleModelId = entity.VehicleModelId,
                        VehicleMakeId = entity.VehicleModel.VehicleMakeId,
                        HasToilet = entity.HasToilet,
                        HasWifi = entity.HasWifi,
                        Year = entity.Year,
                        SeatCount = entity.SeatCount,
                    }).SingleOrDefault(entity => entity.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public IEnumerable<VehicleDefinitionSummary> GetSummaries()
        {
            try
            {
                return _dbContext.VehicleDefinitions
                    .Select(entity => new VehicleDefinitionSummary()
                    {
                        Id = entity.Id,
                        VehicleMakeName = entity.VehicleModel.VehicleMake.Name,
                        VehicleModelName = entity.VehicleModel.Name,
                        Year = entity.Year,
                        SeatCount = entity.SeatCount,
                        HasToilet = entity.HasToilet,
                        HasWifi = entity.HasWifi
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDefinitionSummary>();
            }
        }

        public CommandResult Update(VehicleDefinitionDto model)
        {
            if (model == null)
            {
                // Genel olarak bu tekniğe Guard veya Defensive Coding deniyor
                //throw new ArgumentNullException(nameof(model), "VehicleMakeDto nesnesi null değer olamaz");
                return CommandResult.Failure("Model nesnesi null olamaz");
            }

            
          

            try
            {
                var vehicleDef = _dbContext.VehicleDefinitions.Find(model.Id);
                _dbContext.Update(vehicleDef);
                _dbContext.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Bir hata meydana geldi, sistem yöneticisine başvurun");
            }
        }
    }
}
