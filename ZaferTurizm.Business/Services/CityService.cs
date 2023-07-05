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
    public class CityService : BaseService<CityDto, CitySummary, City>, ICityService
    {
        public CityService(TourDbContext dbContext, GenericValidator<City> validator) : base(dbContext, validator)
        {
        }

        protected override Expression<Func<City, CityDto>> DtoMapper =>
            entity => new CityDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        protected override Expression<Func<City, CitySummary>> SummaryMapper =>
            entity => new CitySummary()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        protected override City MapToEntity(CityDto dto)
        {
            return new City()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
