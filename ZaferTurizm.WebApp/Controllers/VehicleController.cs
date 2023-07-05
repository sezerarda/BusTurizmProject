using Microsoft.AspNetCore.Mvc;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
