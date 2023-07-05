using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IVehicleModelService : IBaseService<VehicleModelDto, VehicleModelSummary>
    {
        IEnumerable<VehicleModelDto> GetByMakeId(int MakeId);
    }
}
