using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using ZaferTurizm.Business.Services;
//using ZaferTurizm.Business.TicketPrinter.Business;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly IBusTripService _busTripService;
        private readonly ITicketService _ticketService;

        public TicketController(IBusTripService busTripService, ITicketService ticketService)
        {
            _busTripService = busTripService;
            _ticketService = ticketService;
        }

        public IActionResult TicketsOfBusTrip(int busTripId)
        {
            //var soldSeatNumbers = _ticketService.GetSoldSeatNumbers(busTripId);
            var busTripDetails =_busTripService.GetBusTripDetails(busTripId);

            if (busTripDetails == null)
            {
                TempData["ErrorMessage"] = "Seyehat Bulunamadı";
                return RedirectToAction("Index", "BusTrip");
            }
            
                
            var reservedSeats = _ticketService.GetReservedSeats(busTripId);

            //busTripDetails.SeatStatuses = new List<SeatStatusDto>();

            //busTripDetails.SoldSeatNumbers ??= new List<int>();

            //foreach (var seatNumber in busTripDetails.SoldSeatNumbers)
            //{
            //    var isReserved = reservedSeats.Any(s => s.SeatNumber == seatNumber);
            //    var seatStatus = new SeatStatusDto { SeatNumber = seatNumber, IsReserved = isReserved };
            //    busTripDetails.SeatStatuses.Add(seatStatus);
            //}

            //foreach (var seatNumber in busTripDetails.Status)
            //{
            //    var isReserved = reservedSeats.Any(s => s.SeatNumber == seatNumber);
            //    var isSold = reservedSeats.Any(s => s.SeatNumber == seatNumber && s.SeatStatus);
            //    var seatStatus = new SeatStatusDto { SeatNumber = seatNumber, IsReserved = isReserved, IsSold = isSold };
            //    busTripDetails.SeatStatuses.Add(seatStatus);
            //}
            
            return View(busTripDetails);
            //return Ok(busTripDetails);
        }

        [HttpPost]
        public IActionResult Create(TicketDto ticket) 
        {
            var result = _ticketService.Create(ticket);

            return Json(result);
        }

        //[HttpGet]
        //public IActionResult GetSeatStatus(int ticketId)
        //{
        //    var seatStatus = _ticketService.GetSeatStatus(ticketId);

        //    if (seatStatus == true)
        //    {
        //        return Content("reserved");
        //    }

        //    return Content("available");
        //}

        //public IActionResult TicketPrint(int id)
        //{
        //    var ticket = _ticketService.GetById(id);
        //    if (ticket == null)
        //    {
        //        return View();
        //    }

        //    TicketPrinter printer = new TicketPrinter();
        //    printer.PrintTicket(ticket);

        //    string fileName = ticket.CustomerName + ticket.CustomerSurname + ticket.CustomerIdentityNumber + "ticket.pdf";
        //    string fullFileName = $@"C:\Users\ASUS\Desktop\Emre Hoca Wissen\ZaferTurizm\Biletler{fileName}";
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(fullFileName);
        //    string contentType = "application/pdf";

        //    Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName);
        //    return File(fileBytes, contentType);


        //}

        public IActionResult TicketsList(int busTripId)
        {
            // BusTripId'ye göre BusTripDetails'ı veritabanından al
            BusTripDetails tripDetails = _busTripService.GetBusTripDetails(busTripId);

            if (tripDetails == null)
            {
                // Hata durumunu işle
                return NotFound();
            }

            return View(tripDetails);
            
        }


    }
}
