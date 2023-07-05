using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface __IBusTripService
    {
        CommandResult Create(BusTripDto model);
        CommandResult Update(BusTripDto model);
        CommandResult Delete(BusTripDto model);  
        CommandResult Delete (int id);
        BusTripDto GetById(int id);
        IEnumerable<BusTripDto> GetAll();
    }
}
