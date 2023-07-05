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
    public class TicketService : BaseService<TicketDto, TicketSummary, Ticket>, ITicketService
    {
        public TicketService(TourDbContext dbContext, GenericValidator<Ticket> validator) : base(dbContext, validator)
        {
        }

        protected override Expression<Func<Ticket, TicketDto>> DtoMapper =>
            entity => new TicketDto()
            {
                BusTripId = entity.BusTripId,
                Price = entity.Price,
                Id = entity.Id,
                CustomerName = entity.Customer.Name,
                CustomerSurname = entity.Customer.Surname,
                CustomerIdentityNumber = entity.Customer.IdentityNumber,
                SeatNumber= entity.SeatNumber,
                SeatStatus = entity.seatStatus,
                TicketNumber =entity.TicketNumber
                
                
            };

        protected override Expression<Func<Ticket, TicketSummary>> SummaryMapper =>
            entity => new TicketSummary()
            {
                BusTripId = entity.BusTripId,
                Id = entity.Id,
                TicketNumber= entity.TicketNumber,
                SeatNumber= entity.SeatNumber,
                CustomerIdentityNumber = entity.Customer.IdentityNumber,
                CustomerName= entity.Customer.Name,
                CustomerSurname= entity.Customer.Surname,
                Price = entity.Price

            };

        protected override Ticket MapToEntity(TicketDto dto)
        {
            return new Ticket()
            {
                BusTripId = dto.BusTripId,
                Price = dto.Price,
                Id = dto.Id,
                SeatNumber= dto.SeatNumber,
                seatStatus = dto.SeatStatus,
                TicketNumber= dto.TicketNumber
               

                
                
                //seatStatus= dto.seatStatus
                
            };
        }

        public override CommandResult Create(TicketDto model)
        {
            try
            {
                var customer = _dbContext.Customers
                     .FirstOrDefault(cust => cust.Name == model.CustomerName &&
                                             cust.Surname == model.CustomerSurname &&
                                             cust.IdentityNumber == model.CustomerIdentityNumber);
                if (customer == null)
                {
                    customer = new Customer()
                    {
                        Name = model.CustomerName,
                        Surname = model.CustomerSurname,
                        IdentityNumber = model.CustomerIdentityNumber,
                        Gender = Gender.None
                    };

                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();
                }
                var existingTicket = _dbContext.Tickets.FirstOrDefault(t => t.SeatNumber == model.SeatNumber && t.BusTripId == model.BusTripId);
                if (existingTicket != null)
                {
                    return CommandResult.Failure("Koltuk dolu.");
                }

                var ticket = new Ticket()
                {
                   BusTripId = model.BusTripId,
                   CustomerId = customer.Id,
                   Price = model.Price,
                   SeatNumber= model.SeatNumber,
                   seatStatus = true
                   
                };
                


                _dbContext.Tickets.Add(ticket);
                _dbContext.SaveChanges();

                return CommandResult.Success("Bilet Başarıyla Kaydedildi");
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public IEnumerable<TicketDto> GetReservedSeats(int busTripId)
        {
            var reservedSeats = _dbContext.Tickets
        .Where(t => t.BusTripId == busTripId && t.seatStatus == true)
        .Select(t => new TicketDto
        {
            SeatNumber = t.SeatNumber
        })
        .ToList();

            return reservedSeats;
        }

        //public TicketDto GetTicketById(int ticketId)
        //{
        //    var ticket = _dbContext.Tickets.FirstOrDefault(t => t.Id == ticketId);

        //if (ticket == null)
        //{
        //    return null;
        //}

        //// TicketDto'ya dönüştürme işlemlerini yap ve dön
        //var ticketDto = new TicketDto
        //{
        //    // Bilet detaylarını TicketDto nesnesine kopyala
        //};

        //return ticketDto;
        //}

        //public TicketDto GetTicketByNumber(int id)
        //{
        //    var ticket = _dbContext.Tickets.FirstOrDefault(t => t.Id == id);

        //    if (ticket == null)
        //    {
        //        return null;
        //    }

        //    var ticketDto = new TicketDto
        //    {
        //        // TicketDto'ya dönüştürme işlemlerini yapın
        //        // Ticket nesnesinden gerekli bilgileri kopyalayın
        //        CustomerName = ticket.Customer.Name,
        //        CustomerSurname = ticket.Customer.Surname,
        //        Price = ticket.Price,
        //        SeatNumber= ticket.SeatNumber,
        //        Id = ticket.Id,
        //        SeatStatus = ticket.seatStatus,
        //        TicketNumber = ticket.TicketNumber,
        //        BusTripId= ticket.BusTripId,
        //        BusTripName = ticket.BusTrip.GetType().Name,
        //        CustomerIdentityNumber = ticket.Customer.IdentityNumber

        //    };

        //    return ticketDto;
        //}

        //IEnumerable<TicketSummary> ITicketService.GetTicketById(int id)
        //{
        //    try
        //    {
        //        var ticket = _dbContext.Tickets
        //            .Where(x => x.Id == id)
        //            .SingleOrDefault();

        //        if (ticket == null)
        //        {
        //            return null;
        //        }


        //        var ticketDto = new TicketDto
        //        {
        //            Id = ticket.Id,
        //            CustomerName = ticket.Customer.Name,
        //            CustomerSurname = ticket.Customer.Surname,
        //            CustomerIdentityNumber = ticket.Customer.IdentityNumber,
        //            BusTripId= ticket.BusTripId,
        //            Price= ticket.Price,
        //            SeatNumber = ticket.SeatNumber,
        //            TicketNumber= ticket.TicketNumber,
        //            SeatStatus = ticket.seatStatus

        //        };

        //        return (IEnumerable<TicketSummary>)ticketDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.TraceError(ex.ToString());
        //        return null;
        //    }
        //}

        public TicketDto GetTicketById(int id)
        {
            try
            {
                var ticket = _dbContext.Tickets
                    .Where(x => x.Id == id)
                    .SingleOrDefault();

                if (ticket == null)
                {
                    return null;
                }

                var ticketDto = new TicketDto
                {
                    Id = ticket.Id,
                    BusTripId = ticket.BusTripId,
                    Price = ticket.Price,
                    SeatNumber = ticket.SeatNumber,
                    TicketNumber = ticket.TicketNumber,
                    SeatStatus = ticket.seatStatus
                };

                return ticketDto;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
    }
}
