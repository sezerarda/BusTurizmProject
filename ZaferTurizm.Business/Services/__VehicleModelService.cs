using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.DataAccess.Migrations;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using VehicleModel = ZaferTurizm.Domain.VehicleModel;

namespace ZaferTurizm.Business.Services
{
    public class __VehicleModelService : __IVehicleModelService
    {
        private readonly TourDbContext _dbContext;

        public __VehicleModelService(TourDbContext tourDbContext)
        {
            _dbContext = tourDbContext;
        }

        public CommandResult Create(VehicleModelDto model)
        {
            
            try
            {
                var entityDefinition = new VehicleModel()
                {
                    Id= model.Id,
                    Name = model.Name,  
                    VehicleMakeId= model.VehicleMakeId

                };
                _dbContext.VehicleModels.Add(entityDefinition); 
                _dbContext.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public CommandResult Delete(VehicleModelDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model null olamaz");
            }
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var entity = new VehicleModel() { Id = id };

            // klasik yöntem
            // Önce kaydı oku (entity izlenmeye başlıyor), sonra Remove ile Context nesnesine silinmesi
            // gerektiğini bildir (State'i Deleted olarak işaretlenecek)
            // entity = _tourDbContext.VehicleMakes.Find(id); 

            try
            {
                _dbContext.VehicleModels.Remove(entity);
                _dbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Bir hata meydana geldi, sistem yöneticisine başvurun");

                //return CommandResult.Error(ex, "Bir hata meydana geldi....");
            }
        }

        public IEnumerable<VehicleModelDto> GetAll()
        {
            try
            {
                return _dbContext.VehicleModels
                    .Select(model => new VehicleModelDto()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        VehicleMakeId = model.VehicleMakeId
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelDto>();
                //return new VehicleModelDto[0];
                //return new List<VehicleModelDto>();
            }
        }

        public IEnumerable<VehicleModelSummary> GetSummaries()
        {
            try
            {
                return _dbContext.VehicleModels
                    .Select(model => new VehicleModelSummary()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        VehicleMakeName = model.VehicleMake.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelSummary>();
            }
        }

        public VehicleModelDto GetById(int id)
        {
            var vehicleModel = _dbContext.VehicleModels.Find(id);
            try
            {
                var vehicleModelDto = new VehicleModelDto()
                {
                    Id = id,
                    Name = vehicleModel.Name,
                    VehicleMakeId = vehicleModel.VehicleMakeId

                };
                return vehicleModelDto;
            }
            catch (Exception ex)
            {

                CommandResult.Failure("id bulunamadı");
                return null;
            }
        }

        public CommandResult Update(VehicleModelDto model)
        {
            try
            {
                var vehicleModel = _dbContext.VehicleModels.Find(model.Id);
                _dbContext.Update(vehicleModel);
                _dbContext.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId)
        {
            try
            {
                return _dbContext.VehicleModels
                    .Where(entity => entity.VehicleMakeId == vehicleMakeId)
                    .Select(entity => new VehicleModelDto()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        VehicleMakeId = entity.VehicleMakeId
                    }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return new List<VehicleModelDto>();
            }
        }
    }
}
