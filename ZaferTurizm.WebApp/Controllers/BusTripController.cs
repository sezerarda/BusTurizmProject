using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Jsoup.Nodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using Document = iText.Layout.Document;

namespace ZaferTurizm.WebApp.Controllers
{
    public class BusTripController : Controller
    {
        private readonly IBusTripService _busTripService;
        private readonly IVehicleRouteService _vehicleRoute;
        private readonly IVehicleService _vehicleService;
        private readonly ITicketService _ticketService;

        public BusTripController(IBusTripService busTripService,
            IVehicleRouteService vehicleRoute,
            IVehicleService vehicleService,
            ITicketService ticketService)
        {
            _busTripService = busTripService;
            _vehicleRoute = vehicleRoute;
            _vehicleService = vehicleService;
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            var busTrips = _busTripService.GetSummaries();

            return View(busTrips);
        }
        public IActionResult Create()
        {
            FillRouteAndVehicle();

            return View();
        }

        public void FillRouteAndVehicle()
        {
            var routeSummaries = _vehicleRoute.GetSummaries();
            var vehicleSummaries = _vehicleService.GetSummaries();

            ViewBag.RouteSelectList = new SelectList(routeSummaries, "Id", "RouteName");
            ViewBag.VehicleSelectList = new SelectList(vehicleSummaries, "Id", "VehicleDescription");
        }

        [HttpPost]
        public IActionResult Create(BusTripDto dto)
        {
            var result = _busTripService.Create(dto);

            if (result.IsSuccess)
            {
                //ViewBag.SuccessMessage = result.Message;
                TempData["SuccessMessage"] = result.Message;

                return RedirectToAction(nameof(Index));
            }
            else
            {
                FillRouteAndVehicle();

                ViewBag.ErrorMessage = result.Message.Replace("\n", "<br>");

                return View(dto);
            }
        }

        public byte[] GeneratePdf(TicketDto ticketDto)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // PDF içeriğini oluşturun
                document.Add(new Paragraph("Bus Trip Details"));
                document.Add(new Paragraph($"Bus Trip Name: {ticketDto.BusTripName}"));
          

                // Biletlerin listesini ekle
                var table = new Table(5);
                table.AddCell($"Ticket Number : {ticketDto.Id}");
                table.AddCell($"Customer Name : {ticketDto.CustomerName}");
                table.AddCell($"Customer Surname : {ticketDto.CustomerSurname}");
                table.AddCell($"Seat Number : {ticketDto.SeatNumber}");
                table.AddCell($"Price : {ticketDto.Price}TL");

             

                document.Add(table);

                // PDF'yi tamamlayın
                document.Close();

                // PDF'yi byte dizisine dönüştürün ve döndürün
                return stream.ToArray();
            }
        }
        public IActionResult GeneratePdfs(int id)
        {
            var busTrip = _ticketService.GetTicketById(id);

            if (busTrip == null)
            {
                return NotFound();
            }

            byte[] pdfBytes = GeneratePdf(busTrip);

            // PDF'yi indirme olarak sunmak için Response olarak geri döndür
            return File(pdfBytes, "application/pdf", "busTrip.pdf");
        }

        private byte[] GeneratePdf(TicketSummary busTrip)
        {
            throw new NotImplementedException();
        }

        
    }
}
