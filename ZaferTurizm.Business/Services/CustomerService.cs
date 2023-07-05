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
    public class CustomerService : BaseService<CustomerDto, CustomerSummary, Customer>, ICustomerService
    {
        public CustomerService(TourDbContext dbContext, GenericValidator<Customer> validator) : base(dbContext, validator)
        {
        }

        protected override Expression<Func<Customer, CustomerDto>> DtoMapper =>
            entity => new CustomerDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                IdentityNumber = entity.IdentityNumber,
                Gender = entity.Gender
            };

        protected override Expression<Func<Customer, CustomerSummary>> SummaryMapper =>
            entity => new CustomerSummary()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                IdentityNumber = entity.IdentityNumber,
                Gender = entity.Gender
            };
        

        protected override Customer MapToEntity(CustomerDto dto)
        {
            return new Customer()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                IdentityNumber = dto.IdentityNumber,
                Gender = dto.Gender
            };
        }
    }
}
