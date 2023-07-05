using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IBaseService<TDto, TSummary>
    {
        CommandResult Create(TDto model);
        CommandResult Update(TDto model);
        CommandResult Delete(TDto model);
        CommandResult Delete(int id);

        TDto? GetById(int id);
        IEnumerable<TDto> GetAll();
        TSummary? GetSummaryById(int id);
        IEnumerable<TSummary> GetSummaries();
    }
}
